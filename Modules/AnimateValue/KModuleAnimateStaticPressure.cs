using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Animated based on: 'this.vessel.staticPressure'.
/// Value is the static pressure of the atomosphere
/// at the current position of this part's vessel.
/// </summary>
[KPartModuleConfigurationDocumentation(
"\n//Animated based on: 'this.vessel.staticPressure'." +
"\n//Value is the static pressure of the atomosphere" +
"\n//at the current position of this part's vessel.")]
public class KModuleAnimateStaticPressure : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(this.vessel.staticPressure - MinValue) / _Denominator;
    }
}
