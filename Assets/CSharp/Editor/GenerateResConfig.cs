using System.IO;
using UnityEditor;
using UnityEngine;

public class GenerateResConfig : Editor
{
    [MenuItem("Tools/Resourse/Gemerate ResConfig File")]
    public static void Generate()
    {
        //生成资源配置文件
        //1.查找Resource目录下所有预制件完整路径
        string[] resFiles = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Resources" });
        for (int i = 0; i < resFiles.Length; i++)
        {
            resFiles[i] = AssetDatabase.GUIDToAssetPath(resFiles[i]);
           string fileName = Path.GetFileNameWithoutExtension(resFiles[i]);
           string filePath = resFiles[i].Replace("Assets/Resources", string.Empty).Replace(".prefab",string.Empty);
            resFiles[i] = fileName + "=" + filePath;
        }
        //写入文件
        File.WriteAllLines(Application.streamingAssetsPath + "/ConfigMap.txt", resFiles);
        AssetDatabase.Refresh();
    }
}
