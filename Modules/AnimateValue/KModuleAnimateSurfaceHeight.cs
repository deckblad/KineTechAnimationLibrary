using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Value is the current height of the vessel
/// above the surface of the planet. Not to be 
/// confused with altitude which is the height 
/// above sea-level.
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n//Value is the current height of the vessel " +
"\n//above the surface of the planet. Not to be " +
"\n//confused with altitude which is the height " +
"\n//above sea-level.")]
public class KModuleAnimateSurfaceHeight : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        Vector3d radial = 
            this.vessel.transform.position - this.vessel.mainBody.transform.position;

        return (float)((this.vessel.mainBody.pqsController
            .GetSurfaceHeight(radial.normalized) - MinValue) / _Denominator);
    }
}
