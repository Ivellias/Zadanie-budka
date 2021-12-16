using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Vector3 _mousePreviousPosition;
    private Vector3 _mouseDeltaPosition;

    void Start()
    {
        _mousePreviousPosition = Vector3.zero;
        _mouseDeltaPosition = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mouseDeltaPosition = Input.mousePosition - _mousePreviousPosition;

            if (Vector3.Dot(transform.up, Vector3.up) >= 0)
            {
                transform.Rotate(transform.up, -Vector3.Dot(_mouseDeltaPosition, Camera.main.transform.right), Space.World);
            }
            else transform.Rotate(transform.up, Vector3.Dot(_mouseDeltaPosition, Camera.main.transform.right), Space.World);

            transform.Rotate(Camera.main.transform.right, Vector3.Dot(_mouseDeltaPosition, Camera.main.transform.up), Space.World);

        }
        _mousePreviousPosition = Input.mousePosition;
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }
}
