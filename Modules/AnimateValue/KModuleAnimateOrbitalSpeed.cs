using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class KModuleAnimateOrbitalVelocity : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(FlightGlobals.ship_obtSpeed - MinValue) / _Denominator;
    }
}
