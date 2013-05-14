using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Value is the current distance from the vessel's
/// transform to it target. Target is only stored for
/// the active vessel, so when the vessel is not active
/// this is not updated.
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n//Value is the current distance from the vessel's" +
"\n//transform to it target. Target is only stored for" +
"\n//the active vessel, so when the vessel is not active" +
"\n//this is not updated.")]
public class KModuleAnimateTargetDistance : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        if(FlightGlobals.fetch == null)
            return 0f;

        if(this.vessel != FlightGlobals.ActiveVessel)
            return LastNormalTime;

        
        if(FlightGlobals.fetch.VesselTarget == null)
            return 0f;

        Vector3 working = FlightGlobals.fetch.VesselTarget.GetTransform().localPosition;
        working -= this.vessel.transform.position;

        return (float)((working.magnitude - MinValue) / _Denominator);
    }

    protected override void UpdateModule()
    {
        base.UpdateModule();

        this.IsLocked = this.vessel != FlightGlobals.ActiveVessel;  
    }
}
