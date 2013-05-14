using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Animates based on: 'this.vessel.srf_velocity.magnitude'
/// Value is the current speed relative to the part's 
/// vessel's current orbital body's surface. 
/// Also, 's's's's's's's's
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n//Animates based on: 'this.vessel.srf_velocity.magnitude'" +
"\n//Value is the current speed relative to the part's " +
"\n//vessel's current orbital body's surface. " +
"\n//Also, 's's's's's's's's")]
public class KModuleAnimateSurfaceSpeed : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(this.vessel.srf_velocity.magnitude / _Denominator);
    }
}

