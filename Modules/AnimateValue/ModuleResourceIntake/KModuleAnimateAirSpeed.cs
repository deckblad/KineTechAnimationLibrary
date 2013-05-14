using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UnityEngine;

[KRequiresModule(typeof(ModuleResourceIntake))]
public class KModuleAnimateAirSpeed : KModuleAnimateValue
{
    #region KSPFields

    [KConfigDocumentation(
        "True", 
        "When True, the animation will only be evaluated when the Intake on this part is open." +
        "\n\t//When open and the player closes the intake it will be interpolated to 0 value." +
        "\n\t//If set to False, animation will be evaluated regardless of intake state.")]
    [KSPFieldDebug("IntakeMustBeOpen")]
    public bool IntakeMustBeOpen = false;

    [KSPFieldDebug("LastNormalTime", isPersistant = true)]
    public float LastNormalTime = 0;

    [KSPFieldDebug("LerpDamp")]
    public float LerpDampening = 1;

    #endregion

    #region Fields

    private FieldInfo _AirSpeed;
    private FieldInfo _IntakeOpen;
    private ModuleResourceIntake _Intake;

    private double AirSpeed
    {
        get
        {
            return _AirSpeed != null && _Intake != null ?
                (double)_AirSpeed.GetValue(_Intake) :
                0;
        }
    }

    #endregion

    #region Logic

    protected override bool SetupModule()
    {
        if(!base.SetupModule())
            return false;

        foreach (PartModule current in part.Modules)
        {
            if (current.GetType().UnderlyingSystemType != typeof(ModuleResourceIntake))
                continue;

            _Intake = current as ModuleResourceIntake;

            foreach (FieldInfo cField in _Intake.GetType().UnderlyingSystemType.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!cField.FieldType.IsPrimitive)
                    continue;

                if (_AirSpeed == null && cField.FieldType == typeof(float))
                {
                    if (!string.Equals(cField.Name, "airSpeedGui"))
                        continue;

                    _AirSpeed = cField;

                    if (!IntakeMustBeOpen || _IntakeOpen != null)
                        break;
                    else
                        continue;
                }

                if(!IntakeMustBeOpen)
                    continue;

                if (cField.FieldType == typeof(bool))
                {
                    if (!string.Equals(cField.Name, "intakeEnabled"))
                        continue;

                    _IntakeOpen = cField;

                    if (_AirSpeed != null)
                        break;
                    else
                        continue;
                }
            }

            break;
        }

        return _AirSpeed != null 
            && _Intake != null 
            && _IntakeOpen != null;
    }

    protected override float SolveNormalTime()
    {
        
        LastNormalTime =
            Mathf.Lerp(
                LastNormalTime,
                Mathf.Clamp01((float)(AirSpeed - MinValue) / _Denominator),
                Time.deltaTime * LerpDampening);
        return LastNormalTime;
    }

    #endregion
}
