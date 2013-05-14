using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UnityEngine;
/// <summary>
/// Value is the speed of the air flowing 
/// into the ModuleResourceIntake on our part.
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n\\Value is the speed of the air flowing " +
"\n\\into the ModuleResourceIntake on our part.")]
[KRequiresModule(typeof(ModuleResourceIntake))]
public class KModuleAnimateAirSpeed : KModuleAnimateValue
{
    #region KSPFields

    [KPartModuleFieldConfigurationDocumentation(
        "True",
        "When True, the animation will only be evaluated when the Intake on this part is open." +
        "\n\t//When open and the player closes the intake it will be interpolated to 0 value." +
        "\n\t//If set to False, animation will be evaluated regardless of intake state.")]
    [KSPFieldDebug("IntakeMustBeOpen")]
    public bool IntakeMustBeOpen = false;

    #endregion

    #region Fields

    /// <summary>
    /// ModuleResourceIntake.airSpeedGui
    /// </summary>
    private FieldInfo _AirSpeed;

    /// <summary>
    /// ModuleResourceIntake.intakeEnabled
    /// </summary>
    private FieldInfo _IntakeOpen;

    /// <summary>
    /// The ModuleResourceIntake that is also within
    /// our part.
    /// </summary>
    private ModuleResourceIntake _Intake;

    /// <summary>
    /// The air speed of the ModuleResourceIntake 
    /// that is also a module within this part.
    /// </summary>
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

        foreach(PartModule current in part.Modules)
        {
            if(current.GetType().UnderlyingSystemType != typeof(ModuleResourceIntake))
                continue;

            _Intake = current as ModuleResourceIntake;
            _AirSpeed = _Intake.GetType().GetField("airSpeedGui");
            _IntakeOpen = _Intake.GetType().GetField("intakeEnabled");
            break;
        }

        return _Intake != null
            && _AirSpeed != null
            && _IntakeOpen != null;
    }

    protected override float SolveNormalTime()
    {
        return (float)((AirSpeed - MinValue) / _Denominator);
    }

    #endregion
}
