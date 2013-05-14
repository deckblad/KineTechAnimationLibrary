using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// Animates based on: 'KSP.FlightGlobals.ship_tgtSpeed'. 
/// If target is lost/deselected, and interpolation is 
/// not active the value will jump back to 0.0f.
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n//Animates based on: 'KSP.FlightGlobals.ship_tgtSpeed'. " +
"\n//If target is lost/deselected, and interpolation is " +
"\n//not active the value will jump back to 0.0f.")]
public class KModuleAnimateTargetSpeed : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        if(FlightGlobals.fetch == null)
            return 0f;

        if(this.vessel != FlightGlobals.ActiveVessel)
            return LastNormalTime;

        if(FlightGlobals.fetch.VesselTarget == null)
            return 0f;

        return (float)((FlightGlobals.ship_tgtSpeed - MinValue) / _Denominator);
    }

    protected override void UpdateModule()
    {
        base.UpdateModule();

        this.IsLocked = this.vessel != FlightGlobals.ActiveVessel;
    }
}
