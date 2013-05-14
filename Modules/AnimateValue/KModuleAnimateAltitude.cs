using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class KModuleAnimateAltitude : KModuleAnimateValue
{
#if DEBUG_ANIM_VALUE
    [KSPField(guiActive = true, guiName = "Altitude")]
    public float butt;
#endif


    protected override float SolveNormalTime()
    {
        return (float)(FlightGlobals.ship_altitude - MinValue) / _Denominator;
    }
}
