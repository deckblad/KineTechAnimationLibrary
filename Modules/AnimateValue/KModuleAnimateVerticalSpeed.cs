using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class KModuleAnimateVerticalSpeed : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(FlightGlobals.ship_verticalSpeed - MinValue) / _Denominator;
    }
}
