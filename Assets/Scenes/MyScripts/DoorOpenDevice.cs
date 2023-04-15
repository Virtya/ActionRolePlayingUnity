using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField] private Vector3 dPos;

    private bool _open;

    public void Operate()
    {
        if (_open)
        {
            Vector3 pos = transform.position - dPos;
            //transform.position = pos;
            iTween.MoveTo(gameObject, iTween.Hash("position", pos, "speed", 2.0f));
        } else
        {
            Vector3 pos = transform.position + dPos;
            //transform.position = pos;
            iTween.MoveTo(gameObject, iTween.Hash("position", pos, "speed", 2.0f));
        }
        _open = !_open;
    }

    public void Activate()
    {
        if (!_open)
        {
            Vector3 pos = transform.position + dPos;
            iTween.MoveTo(gameObject, iTween.Hash("position", pos, "speed", 2.0f));
            _open = true;
        }
    }

    public void Deactivate()
    {
        if (_open)
        {
            Vector3 pos = transform.position - dPos;
            iTween.MoveTo(gameObject, iTween.Hash("position", pos, "speed", 2.0f));
            _open = false;
        }
    }
}
