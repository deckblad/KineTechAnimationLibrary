using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[KRequiresModule(typeof(ModuleDeployableSolarPanel))]
public class KModuleAnimateGeeForce : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(FlightGlobals.ship_geeForce - MinValue) / _Denominator;
    }
}
