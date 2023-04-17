using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkService : MonoBehaviour
{
    private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?q=Voronezh&mode=xml&APPID=01c09d390c387a780cef56c810cd457d";

    private const string webImage = "https://papik.pro/uploads/posts/2023-03/1677786442_papik-pro-p-samii-krasivii-peizazh-risunok-2.jpg";
    private const string localApi = "http://localhost/UnityGameServ/api.php";

    //https://api.openweathermap.org/data/2.5/weather?q=Chicago,us&mode=xml

    [System.Obsolete]
    private bool IsResponseValid(WWW www)
    {
        if (www.error != null)
        {
            Debug.LogWarning(www.error);
            return false;
        }
        else if (string.IsNullOrEmpty(www.text))
        {
            Debug.Log("bad data");
            return false;
        }
        else
        {
            return true;
        }
    }

    [Obsolete]
    private IEnumerator CallAPI(string url, Hashtable args, Action<string> callback)
    {
        WWW www;
        if (args == null)
        {
            www = new WWW(url);
        } else
        {
            WWWForm form = new WWWForm();
            foreach (DictionaryEntry arg in args)
            {
                form.AddField(arg.Key.ToString(), arg.Value.ToString());
            }
            www = new WWW(url, form);
        }

        yield return www;

        if (!IsResponseValid(www))
        {
            yield break;
        }

        callback(www.text);
    }

    [Obsolete]
    public IEnumerator GetWeatherXML(Action<string> callback)
    {
        return CallAPI(xmlApi, null, callback);
    }

    [Obsolete]
    public IEnumerator DownloadImage(Action<Texture2D> callback)
    {
        WWW www = new WWW(webImage);
        yield return www;
        callback(www.texture);
    }

    [Obsolete]
    public IEnumerator LogWeather(string name, float cloudValue, Action<string> callback)
    {
        Hashtable args = new Hashtable
        {
            { "message", name },
            { "cloud_value", cloudValue },
            { "timestamp", DateTime.UtcNow.Ticks }
        };

        return CallAPI(localApi, args, callback);
    }
}
