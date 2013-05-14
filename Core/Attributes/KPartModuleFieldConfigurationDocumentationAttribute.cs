using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using KSP.IO;

/// <summary>
/// Used for documenting usage of a field 
/// that will be serialized with a 'KSP.ConfigNode';
/// </summary>
[AttributeUsage(AttributeTargets.Field , AllowMultiple=false, Inherited=true)]
public class KPartModuleFieldConfigurationDocumentationAttribute : Attribute
{
    public readonly string DefaultValue;
    public readonly string Description;

    public KPartModuleFieldConfigurationDocumentationAttribute(string defaultValue, string description)
    {
        if (string.IsNullOrEmpty(defaultValue))
            throw new ArgumentNullException("defaultValue");

        if (string.IsNullOrEmpty(description))
            throw new ArgumentNullException("description");

        this.DefaultValue = defaultValue;
        this.Description = description;
    }
}
