using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Animates based on: 'this.vessel.altitude'.
/// Value is the current altitude of the part's
/// vessel relative to sealevel of it's current 
/// main body.
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n//Animates based on: 'this.vessel.altitude'."+
"\n//Value is the current altitude of the part's" +
"\n//vessel relative to sealevel of it's current " +
"\n//main body.")]
public class KModuleAnimateAltitude : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(this.vessel.altitude - MinValue) / _Denominator;
    }
}
