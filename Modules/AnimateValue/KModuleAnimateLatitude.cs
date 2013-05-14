using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Animates based on: 'this.vessel.latitude'. 
/// Value is the current latitude of the part's
/// vessel relative to its current mainbody.
/// An interesting part shall use this :)
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n//Animates based on: 'this.vessel.latitude'. " +
"\n//Value is the current latitude of the part's" +
"\n//vessel relative to its current mainbody." +
"\n//An interesting part shall use this :)")]
public class KModuleAnimateLatitude : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(this.vessel.latitude - MinValue) / _Denominator;
    }
}

