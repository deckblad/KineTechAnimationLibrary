using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Animates based on: 'this.vessel.atmDensity'. 
/// Value is the density of the atomosphere within
/// the current mainbody of this part's vessel.
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n//Animates based on: 'this.vessel.atmDensity'. " +
"\n//Value is the density of the atomosphere within" +
"\n//the current mainbody of this part's vessel.")]
public class KModuleAnimateAtmosphericDensity : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(this.vessel.atmDensity - MinValue) / _Denominator;
    }
}
