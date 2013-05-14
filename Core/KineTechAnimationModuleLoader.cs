using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSP.IO;
using UnityEngine;

public class KineTechAnimationModuleLoader : KSP.Testing.UnitTest
{
    private const string SETTINGS_FILE_NAME = "Settings.KineTechAnimation";


    public KineTechAnimationModuleLoader()
        : base()
    {
        HandleSettings();
    }

    public void HandleSettings()
    {
        if (!File.Exists<KineTechAnimationModuleLoader>(SETTINGS_FILE_NAME))
        {
            ConfigNode node = new ConfigNode();
            node.AddValue("DumpDocumentationOnStartup", false);
            node.Save(IOUtils.GetFilePathFor(typeof(KineTechAnimationModuleLoader), SETTINGS_FILE_NAME));
        }

        if (File.Exists<KineTechAnimationModuleLoader>(SETTINGS_FILE_NAME))
        {
            ConfigNode node = ConfigNode.Load(
                IOUtils.GetFilePathFor(typeof(KineTechAnimationModuleLoader), SETTINGS_FILE_NAME));

            if(node == null)
                return;

            //Dump Documentation
            if(node.HasValue("DumpDocumentationOnStartup"))
            {
                bool working = false;
                if(bool.TryParse(node.GetValue("DumpDocumentationOnStartup"), out working))
                {
                    GameObject dumperObject = new GameObject("Kine-Tech Animation - ConfigDocumentationGenerator");
                    dumperObject.AddComponent<KConfigDocumentationGenerator>();
                    GameObject.DontDestroyOnLoad(dumperObject);
                }
            }
                
        }
    }
}
