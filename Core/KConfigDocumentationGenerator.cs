using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class KConfigDocumentationGenerator : MonoBehaviour
{
    private void OnLevelWasLoaded(int level)
    {
        if (HighLogic.LoadedScene < GameScenes.MAINMENU)
            return;

        KConfigDocumentationAttribute.GenerateDocumentation();
        DestroyImmediate(this.gameObject);
    }
}
