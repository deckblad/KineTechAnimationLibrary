using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class KModuleAnimateAtmosphericDensity : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(FlightGlobals.ship_dns - MinValue) / _Denominator;
    }
}
