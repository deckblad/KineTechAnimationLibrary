using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using KSP.IO;

[AttributeUsage(AttributeTargets.Field , AllowMultiple=false, Inherited=true)]
public class KConfigDocumentationAttribute : Attribute
{
    public readonly string DefaultValue;
    public readonly string Description;

    public KConfigDocumentationAttribute(string defaultValue, string description)
    {
        if (string.IsNullOrEmpty(defaultValue))
            throw new ArgumentNullException("defaultValue");

        if (string.IsNullOrEmpty(description))
            throw new ArgumentNullException("description");

        this.DefaultValue = defaultValue;
        this.Description = description;
    }

    public static void AddValueToNode(ref StringBuilder working, FieldInfo field, KConfigDocumentationAttribute attribute)
    {
        if (working == null)
            return;

        if (field == null)
            return;

        if (attribute == null)
            return;

        //Create description;

        working.Append("\t//");
        working.AppendLine(attribute.Description);
        
        //WriteValue
        working.Append("\t");
        working.Append(field.Name);
        working.Append(" = ");
        working.AppendLine(attribute.DefaultValue);
        working.AppendLine();
    }

    public static bool AddModule(ref StringBuilder working, Type moduleType)
    {
        if(working == null)
            return false;

        if(moduleType == null)
            return false;
        
        if (!typeof(PartModule).IsAssignableFrom(moduleType))
            return false;

        bool hasDocumentation = false;

        working.AppendLine();

        working.AppendLine("MODULE");
        working.AppendLine("{");
        working.Append("\tname = ");
        working.AppendLine(moduleType.Name);
        working.AppendLine();
        foreach (FieldInfo current in
            moduleType.UnderlyingSystemType.GetFields(BindingFlags.Public | BindingFlags.Instance))
        {
            object[] objs = current.GetCustomAttributes(typeof(KConfigDocumentationAttribute), true);

            if (objs == null || objs.Length != 1)
                continue;

            KConfigDocumentationAttribute attr = objs[0] as KConfigDocumentationAttribute;

            if (attr == null)
                continue;

            AddValueToNode(ref working, current, attr);
            hasDocumentation = true;
        }
        working.Remove(working.Length - 1, 1);
        working.AppendLine("}");

        return hasDocumentation;
    }

    public static void GenerateDocumentation()
    {
        foreach (Assembly current in AppDomain.CurrentDomain.GetAssemblies())
            GenerateAssemblyDocumentation(current);
    }

    public static void GenerateAssemblyDocumentation(Assembly assembly)
    {
        string search = "SEARCHSTRING.txt";
        string root = IOUtils.GetFilePathFor(typeof(KineTechAnimationModuleLoader), search);
        root = root.Replace(search, string.Empty);
        
        foreach (Type current in assembly.GetTypes())
        {
            if (!typeof(KModuleAnimate).IsAssignableFrom(current))
                continue;

            if (current.IsAbstract)
                continue;
            
            StringBuilder working = new StringBuilder();

            if (AddModule(ref working, current))
            {
                string fileName;
                if (GetFileNameFor(root, assembly, current, out fileName))
                    File.WriteAllText<KineTechAnimationModuleLoader>(working.ToString(), fileName);
            }
        }
    }

    private static bool GetFileNameFor(string root, Assembly assembly, Type moduleType, out string result)
    {
        result = string.Empty;

        if (string.IsNullOrEmpty(root))
            return false;

        if (assembly == null)
            return false;

        if (moduleType == null)
            return false;

        result = string.Concat(
            root,
            "/",
            assembly.GetName(),
            "/",
            moduleType.Name,
            ".cfg");

        return true;
    }
}
