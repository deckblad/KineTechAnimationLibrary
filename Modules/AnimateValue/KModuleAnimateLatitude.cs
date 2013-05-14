using System;
using System.Collections.Generic;
using System.Text;

public class KModuleAnimateLatitude : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(FlightGlobals.ship_latitude - MinValue) / _Denominator;
    }
}

