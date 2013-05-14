using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class KModuleAnimate : PartModule
{
    #region KSPFields

    [KConfigDocumentation("name of animation", "The name of the animation to be played with this module.")]
    [KSPFieldDebug("AnimationName", isPersistant=true)]
    public string AnimationName = string.Empty;

    [KConfigDocumentation("False", "When True the animation will be played in reverse; otherwise False.")]
    [KSPFieldDebug("PlayInReverse", isPersistant = true)]
    public bool PlayInReverse = false;

    [KSPFieldDebug("AnimationIsLocked?", isPersistant = true)]
    public bool IsLocked = false;

    #endregion

    #region Fields

    protected AnimationState[] _AnimationStates;

    [KSPFieldDebug("IsSetup?")]
    private bool _IsSetup = false;

    [KSPFieldDebug("SetupWasFailed?")]
    private bool _SetupWasFailed = false;
    private int it = 0;

    #endregion

    #region PartModule

    public override void OnAwake()
    {
        base.OnAwake();

        if (!KRequiresModuleAttribute.RequirementsMet(this))
        {
            Debug.LogWarning("Module '" + this.name + "' requires another module which is not present! Shutting down.");
            DestroyImmediate(this);
        }
    }

    public override void OnStart(StartState state)
    {
        SetupAnimation();

        if(!_SetupWasFailed)
            OnModuleStateChanged(state);
    }

    public override void OnUpdate()
    {
        float normalTime = SolveNormalTime();

        UpdateModule(ref normalTime);

        SetAllNormalTimeTo(normalTime);
    }

    public override string GetInfo()
    {
        return "Powered by: [Kine-Tech Animation Library]";
    }
    #endregion

    private void SetupAnimation()
    {
        if (_IsSetup)
            return;
        
        Animation[] anims = base.part.FindModelAnimators(this.AnimationName);
        _AnimationStates = new AnimationState[anims.Length];

        for (int it = 0; it < anims.Length; it++)
        {
            Animation current = anims[it];
            AnimationState animationState = current[this.AnimationName];
            animationState.speed = 0f;
            current.Play(this.AnimationName);
            _AnimationStates[it] = animationState;
        }

        if (!SetupModule())
            this.enabled = false;

        _IsSetup = true;
    }

    
    private void SetAllNormalTimeTo(float normalTime)
    {
        normalTime = PlayInReverse ?
            (Mathf.Clamp01(normalTime) * -1) + 1 :
            (Mathf.Clamp01(normalTime));

        for (it = 0; it < _AnimationStates.Length; it++)
            _AnimationStates[it].normalizedTime = normalTime;
    }

    #region Abstract Methods


    protected virtual void OnModuleStateChanged(StartState state) { }

    protected abstract bool SetupModule();
    protected abstract void UpdateModule(ref float normalTime);
    protected abstract float SolveNormalTime();

    #endregion
}
