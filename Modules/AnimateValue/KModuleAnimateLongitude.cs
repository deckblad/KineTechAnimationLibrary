using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class KModuleAnimateLongitude : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(FlightGlobals.ship_longitude - MinValue) / _Denominator;
    }
}
