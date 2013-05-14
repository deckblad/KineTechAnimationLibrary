using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Used for providing a description of the 
/// PartModule within generated documentation cache.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=false)]
public class KPartModuleConfigurationDocumentationAttribute : System.Attribute
{
    public readonly string ModuleDocumentation;

    public KPartModuleConfigurationDocumentationAttribute(string moduleDocumentation)
    {
        if(string.IsNullOrEmpty(moduleDocumentation))
            throw new ArgumentException("moduleDocumentation");
        
        this.ModuleDocumentation = moduleDocumentation;
    }
}
