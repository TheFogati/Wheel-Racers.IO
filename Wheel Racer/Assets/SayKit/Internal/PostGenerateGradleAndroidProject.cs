#if UNITY_EDITOR && UNITY_ANDROID
using System.IO;

using UnityEngine;
using UnityEditor.Android;
using System.Linq;


public class PostGenerateGradleAndroidProject : IPostGenerateGradleAndroidProject
{
    public int callbackOrder => 0;

    public void OnPostGenerateGradleAndroidProject(string path)
    {
        
#if UNITY_2019_3_OR_NEWER
        UpdateUnityLibraryGradleFile(path);
        
        var unityLibraryPath = path;

        path = path.Replace("unityLibrary", "launcher");
#endif

        UpdateGradleProperties(path);


#if UNITY_2020_2_OR_NEWER
        string stringsXML = Application.dataPath + "/Plugins/Android/saykit/res/values/strings.xml";
        string networkConfigXML = Application.dataPath + "/Plugins/Android/saykit/res/xml/network_security_config.xml";

        string resPath = unityLibraryPath + "/src/main/res";

        Directory.CreateDirectory(resPath + "/xml");
        File.Copy(networkConfigXML, resPath + "/xml/network_security_config.xml", true);

        File.Copy(stringsXML, resPath + "/values/strings.xml", true);
#endif

    }

    public void UpdateGradleProperties(string path)
    {
#if UNITY_2019_3_OR_NEWER
        path = path.Replace("/launcher", "");
#endif

        string gradlePropertiesFile = path + "/gradle.properties";
        
        StreamWriter writer = File.AppendText(gradlePropertiesFile);
        writer.WriteLine("");
        writer.WriteLine("android.useAndroidX=true");
        writer.WriteLine("android.enableJetifier=true");
        writer.Flush();
        writer.Close();
    }

    public void UpdateUnityLibraryGradleFile(string path)
    {
        string gradleFile = path + "/build.gradle";

        var lines = File.ReadAllLines(gradleFile).ToList();


        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].Contains("'UnityAds'"))
            {
                lines[i] = "";
                break;
            }

        }

        File.WriteAllLines(gradleFile, lines.ToArray());
    }
}

#endif