using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class KModuleAnimateTargetSpeed : KModuleAnimateValue
{
    [KSPFieldDebug("LastNormalTime", isPersistant = true)]
    public float LastNormalTime = 0;

    [KSPFieldDebug("LerpDamp")]
    public float LerpDampening = 1;

    protected override float SolveNormalTime()
    {
        LastNormalTime =
            Mathf.Lerp(
                LastNormalTime,
                Mathf.Clamp01((float)(FlightGlobals.ship_tgtSpeed - MinValue) / _Denominator),
                Time.deltaTime * LerpDampening);
        return LastNormalTime;
    }
}
