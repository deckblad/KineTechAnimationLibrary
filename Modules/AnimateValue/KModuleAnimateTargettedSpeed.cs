using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Animates based on: 'KSP.FlightGlobals.ship_tgtSpeed'. 
/// If we are not the target, or the target is 
/// lost/deselected, and interpolation is not active the 
/// value will jump back to 0.0f. Suggested to use in tandem
/// with KModuleAnimateTargetSpeed.
/// </summary>
[KPartModuleConfigurationDocumentation(
"Animates based on: 'KSP.FlightGlobals.ship_tgtSpeed'. " +
"\n//If we are not the target, or the target is " +
"\n//lost/deselected, and interpolation is not active the " +
"\n//value will jump back to 0.0f. Suggested to use in tandem" +
"\n//with KModuleAnimateTargetSpeed.")]

public class KModuleAnimateTargettedSpeed : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        if(FlightGlobals.fetch == null)
            return 0f;

        if(this.vessel == FlightGlobals.ActiveVessel)
            return LastNormalTime;

        if((FlightGlobals.fetch.VesselTarget as Vessel) != this.vessel)
            return 0f;

        return (float)((FlightGlobals.ship_tgtSpeed - MinValue) / _Denominator);
    }

    protected override void UpdateModule()
    {
        base.UpdateModule();

        this.IsLocked = this.vessel == FlightGlobals.ActiveVessel;
    }
}
