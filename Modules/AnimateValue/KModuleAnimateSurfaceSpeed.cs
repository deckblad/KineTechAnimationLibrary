using System;
using System.Collections.Generic;
using System.Text;


public class KModuleAnimateSurfaceSpeed : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(FlightGlobals.ship_srfSpeed - MinValue) / _Denominator;
    }
}

