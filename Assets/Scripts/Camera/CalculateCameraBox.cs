using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateCameraBox : MonoBehaviour
{
    private Camera cam;
    private BoxCollider2D camBox;
    private float sizeX, sizeY, ratio;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        camBox = GetComponent<BoxCollider2D>();

        SetCamBox();
    }

    private void Update()
    {
        //SetCamBox();

    }

    private void SetCamBox()
    {
        sizeY = cam.orthographicSize * 2;
        ratio = (float)Screen.width / (float)Screen.height;
        sizeX = sizeY * ratio;
        camBox.size = new Vector2(sizeX, sizeY);
    }
}
