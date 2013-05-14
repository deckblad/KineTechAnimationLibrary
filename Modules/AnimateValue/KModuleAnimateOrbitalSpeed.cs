using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Animates based on: 'this.vessel.orbit.GetRelativeVel().magnitude'
/// Value is the current speed at which the part's
/// vessel is orbitting it's current mainbody.
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n//Animates based on: 'this.vessel.orbit.GetRelativeVel().magnitude'" +
"\n//Value is the current speed at which the part's" +
"\n//vessel is orbitting it's current mainbody.")]
public class KModuleAnimateOrbitalVelocity : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(this.vessel.orbit.GetRelativeVel().magnitude - MinValue) / _Denominator;
    }
}
