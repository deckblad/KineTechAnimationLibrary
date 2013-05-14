using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Used for allowing fields to be visible on the 
/// partmodule when compiled with 'DEBUG' symbol, 
/// but allowing their display state to be different 
/// when compiled without.
/// </summary>
public class KSPFieldDebugAttribute : KSPField
{
    public readonly bool IsGuiActive;

    /// <summary>
    /// Initializes a new instance of 
    /// the KSPFieldDebugAttribute class.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="isGuiActive"></param>
    public KSPFieldDebugAttribute(string name, bool isGuiActive = false)
    {
        this.guiActive =
#if DEBUG
                        true;
#else
                        isGuiActive;
#endif
        this.guiName = name;
    }
}

