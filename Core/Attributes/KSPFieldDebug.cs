using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class KSPFieldDebugAttribute : KSPField
{
    public readonly bool IsGuiActive;

    public KSPFieldDebugAttribute(string name, bool isGuiActive = false)
    {
        this.guiActive =
#if DEBUG
                        true;
#else
                        false;
#endif
        this.guiName = name;
    }
}

