using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UnityEngine;

//[KRequiresModule(typeof(ModuleDeployableSolarPanel))]
//public class KModuleAnimateSolarCharge : KModuleAnimateValue
//{
//    private ModuleDeployableSolarPanel _SolarPanel;
//    private FieldInfo _FlowRate;

//    private float FlowRate
//    {
//        get
//        {
//            return _FlowRate != null && _SolarPanel != null ?
//                (float)_FlowRate.GetValue(_SolarPanel) :
//                0;
//        }
//    }

//    protected override bool  SetupModule()
//    {
//        if(!base.SetupModule())
//            return false;

//        foreach(PartModule current in part.Modules)
//        {
//            if(current.GetType() != typeof(ModuleDeployableSolarPanel))
//                continue;

//            _SolarPanel = current as ModuleDeployableSolarPanel;
//            break;
//        }

//        if (_SolarPanel != null)
//        {
//            _FlowRate = _SolarPanel.GetType()
//                .GetField("flowRate", BindingFlags.Instance | BindingFlags.Public);
//        }
//        return _FlowRate != null && _SolarPanel != null;
//    }

//    protected override float SolveNormalTime()
//    {
//        LastNormalTime =
//            Mathf.Lerp(
//                LastNormalTime,
//                Mathf.Clamp01((FlowRate - MinValue) / _Denominator),
//                Time.deltaTime * LerpDampening);
//        return LastNormalTime;
//    }

//}

