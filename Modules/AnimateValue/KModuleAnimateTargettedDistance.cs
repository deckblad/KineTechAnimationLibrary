using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Value is the current distance from the active
/// vessel which is tartting us. When we are not
/// targetted, value is 0. Very effective to use in tandem with
/// KModuleAnimateTargetDistance.
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n//Value is the current distance from the active"+
"\n//vessel which is tartting us. When we are not" +
"\n//targetted, value is 0. Very effective to use in tandem with" +
"\n//KModuleAnimateTargetDistance.")]
public class KModuleAnimateTargettedDistance : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        if(FlightGlobals.fetch == null)
            return 0f;

        if(this.vessel == FlightGlobals.ActiveVessel)
            return LastNormalTime;


        if(FlightGlobals.fetch.VesselTarget != this.vessel)
            return 0f;

        Vector3 working = FlightGlobals.ActiveVessel.transform.localPosition;
        working -= this.vessel.transform.position;

        return (float)((working.magnitude - MinValue) / _Denominator);
    }

    protected override void UpdateModule()
    {
        base.UpdateModule();

        this.IsLocked = this.vessel == FlightGlobals.ActiveVessel;
    }
}
