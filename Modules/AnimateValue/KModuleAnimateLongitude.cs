using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Animates based on: 'this.vessel.longitude'. 
/// Value is the current longitude of the part's
/// vessel relative to its current mainbody.
/// An interesting part shall use this :)
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n//Animates based on: 'this.vessel.longitude'. " +
"\n//Value is the current longitude of the part's" +
"\n//vessel relative to its current mainbody." +
"\n//An interesting part shall use this :)")]
public class KModuleAnimateLongitude : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(this.vessel.longitude - MinValue) / _Denominator;
    }
}
