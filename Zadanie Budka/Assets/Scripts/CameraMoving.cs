using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + new Vector3(0.0f, Time.deltaTime * _speed, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + new Vector3(0.0f, -Time.deltaTime * _speed, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(Time.deltaTime * _speed, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-Time.deltaTime * _speed, 0.0f, 0.0f);
        }

    }
}
