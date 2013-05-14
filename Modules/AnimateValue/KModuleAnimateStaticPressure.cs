using System;
using System.Collections.Generic;
using System.Text;


public class KModuleAnimateStaticPressure : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(FlightGlobals.ship_stP - MinValue) / _Denominator;
    }
}
