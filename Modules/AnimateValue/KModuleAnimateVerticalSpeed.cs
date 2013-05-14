/// <summary>
/// Animates based on: 'this.vessel.verticalSpeed'
/// Value is the current vertical speed(away from orbital body)
/// of the part's vessel.
/// </summary>
[KPartModuleConfigurationDocumentationAttribute(
    "\n//Animates based on: 'this.vessel.verticalSpeed'" +
    "\n//Value is the current vertical speed(away from orbital body)" +
    "\n//of the part's vessel.")]
public class KModuleAnimateVerticalSpeed : KModuleAnimateValue
{
    protected override float SolveNormalTime()
    {
        return (float)(this.vessel.verticalSpeed - MinValue) / _Denominator;
    }
}
