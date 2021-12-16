using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    public void TakeScreenshoot()
    {
        if (!Directory.Exists(Application.dataPath + "/Output"))
        {
            Directory.CreateDirectory((Application.dataPath + "/Output"));
        }

        StartCoroutine("TakingScreenhoot");
    }

    public IEnumerator TakingScreenhoot()
    {
        _canvas.enabled = false;
        yield return new WaitForEndOfFrame();
        string currentTime = System.DateTime.Now.ToString().Replace(".", "_").Replace(":", "_") + System.DateTime.Now.Millisecond.ToString();
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/Output/screenshot" + currentTime + ".png");
        _canvas.enabled = true;
    }
}
