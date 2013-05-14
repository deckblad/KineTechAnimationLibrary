using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public abstract class KModuleAnimateValue : KModuleAnimate
{
    #region KSPFields

    [KConfigDocumentation("0", "The minimum value at which the animation will begin interpolating.")]
    [KSPFieldDebug("Min", isPersistant=true)]
    public float MinValue = 0;

    [KConfigDocumentation("1", "The value at which the animation will complete its interpolation.")]
    [KSPFieldDebug("Max", isPersistant = true)]
    public float MaxValue = 1;

    [KConfigDocumentation(
        "True", 
        "When set to False, once the animation has reached the maximum" 
        + "\n\t//value it becomes locked.")]
    [KSPFieldDebug("CanDescendAfterMax?", isPersistant = true)]
    public bool CanDescendAfterMax = true;

    [KSPFieldDebug("IsMaxLocked?", isPersistant = true)]
    public bool IsMaxLocked = false;

    #endregion

    #region Fields

    protected float _Denominator = -1;

    #endregion

    #region KModuleAnimate

    protected override bool SetupModule()
    {
        if (MaxValue <= MinValue)
        {
            Debug.LogError(FormatErrorString(
                "MinValue was greater than or equal to MaxValue!"));

            return false;
        }

        _Denominator = MaxValue - MinValue;

        return true;
    }

    protected override void UpdateModule(ref float normalTime)
    {
        if(!CanDescendAfterMax && !IsMaxLocked)
            IsMaxLocked = normalTime >= 1.0f;
        
        if (IsMaxLocked)
            normalTime = 1.0f;
    }

    #endregion

    private string FormatErrorString(string message)
    {
        return string.Format(
            "\n[KModuleAnimateSurfaceVelocity]\nMaxVelocity:{0}\nMinVelocity:{1}\nAnimationName:{2}\nMessage:{3}",
            MaxValue,
            MinValue,
            AnimationName,
            message);
    }
}
