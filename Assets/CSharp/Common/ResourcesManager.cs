using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ResourcesManager
{
    private static Dictionary<string, string> configMap;
    static ResourcesManager()
    {
       string fileContent = GetConfigFile();
        BuildMap(fileContent);
    }

    private static void BuildMap(string fileContent)
    {
        configMap = new Dictionary<string, string>();

    }

    private static string GetConfigFile()
    {
        string url = "file://" + Application.streamingAssetsPath + "/ConfigMap.txt";
        UnityWebRequest web = UnityWebRequest.Get(url);
        while (true)
        {
            if(web.isDone)
            {
                return web.downloadHandler.text;
            }    
        }
    }

    public static T Load<T>(string prefabName) where T: Object
    {
        string prefabPath = configMap[prefabName];
        return Resources.Load<T>(prefabName);
    }
}
