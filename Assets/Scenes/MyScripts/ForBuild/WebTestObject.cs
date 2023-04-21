using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTestObject : MonoBehaviour
{
    private string _message;

    private void Start()
    {
        _message = "No message yet";
    }

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.ExternalCall("ShowAlert", "Hello out there!");
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), _message);
    }

    public void RespondToBrowser(string message)
    {
        _message = message;
    }
}
