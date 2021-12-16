using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] private float zoomStrength = 4.0f;

    private Camera _cam;
    private float _targetSize;

    void Start()
    {
        _cam = GetComponent<Camera>();
        _targetSize = _cam.orthographicSize;
    }

    void Update()
    {
        float scrolldata = Input.GetAxisRaw("Mouse ScrollWheel");
        _targetSize -= scrolldata * zoomStrength;
        if (_targetSize < 0.05f) _targetSize = 0.05f;
        if (_targetSize > 50.0f) _targetSize = 50.0f;
        _cam.orthographicSize = Mathf.Lerp(_cam.orthographicSize, _targetSize, Time.deltaTime * 15.0f);
    }
}
