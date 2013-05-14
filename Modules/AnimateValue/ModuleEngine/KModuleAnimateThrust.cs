using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

/// <summary>
/// Value is the amount of thrust currently
/// being produced by the ModuleEngines that
/// is attached to our part.
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n//Value is the amount of thrust currently" +
"\n//being produced by the ModuleEngines that" +
"\n//is attached to our part.")]
[KRequiresModule(typeof(ModuleEngines))]
public class KModuleAnimateThrust : KModuleAnimateValue
{
    [KPartModuleFieldConfigurationDocumentation("True", "When True, the maximum thrust of the engine will be used as MaxValue; otherwise False.")]
    [KSPFieldDebug("UseMaxThrust", false, isPersistant=true)]
    public bool UseMaxThrust = true;
    
    private ModuleEngines _Engine;
    private FieldInfo _Thrust;

    private float _CurrentThrust { get { return _Thrust != null && _Engine != null ? (float)_Thrust.GetValue(_Engine) : 0f; } }

    protected override bool SetupModule()
    {
        foreach (PartModule cModule in part.Modules)
        {
            if (cModule.GetType() != typeof(ModuleEngines))
                continue;

            _Engine = cModule as ModuleEngines;
            break;
        }

        if (_Engine != null)
        {
            _Thrust = _Engine.GetType().GetField("finalThrust");

            if(UseMaxThrust)
                this.MaxValue = _Engine.maxThrust;
        }

        return base.SetupModule();
    }

    protected override float SolveNormalTime()
    {
        return (float)(_CurrentThrust - MinValue) / _Denominator;
    }
}
