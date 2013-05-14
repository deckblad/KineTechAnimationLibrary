using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=true)]
public class KRequiresModuleAttribute : System.Attribute
{
    public readonly Type RequiredType;

    public KRequiresModuleAttribute(Type requires)
    {
        if (requires == null)
            throw new ArgumentNullException();

        this.RequiredType = requires;
    }

    public static bool RequirementsMet(KModuleAnimate animate)
    {
        if(animate == null)
            return false;

        object[] objs = animate.GetType().UnderlyingSystemType.GetCustomAttributes(typeof(KRequiresModuleAttribute), true);

        if(objs.Length != 1)
            return false;

        KRequiresModuleAttribute attr =  objs[0] as KRequiresModuleAttribute;

        if(attr == null)
            return false;


        foreach (PartModule current in animate.part.Modules)
        {
            if (current.GetType().UnderlyingSystemType != attr.RequiredType)
                continue;

            return true;
        }

        return false;
    }
}

