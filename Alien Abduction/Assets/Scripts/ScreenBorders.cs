using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorders : MonoBehaviour
{
    void Awake()
    {
        AddBorders();
    }

    void AddBorders()
    {
        if (Camera.main == null)
        {
            Debug.Log("Camera not found");
            return;
        }
        else
        {
            Camera oCamera = Camera.main;
            if (!oCamera.orthographic) return;

            var vBottomLeft = (Vector2)oCamera.ScreenToWorldPoint(new Vector3(0, 0, oCamera.nearClipPlane));
            var vTopLeft = (Vector2)oCamera.ScreenToWorldPoint(new Vector3(0, oCamera.pixelHeight, oCamera.nearClipPlane));
            var vTopRight = (Vector2)oCamera.ScreenToWorldPoint(new Vector3(oCamera.pixelWidth, oCamera.pixelHeight, oCamera.nearClipPlane));
            var vBottomRight = (Vector2)oCamera.ScreenToWorldPoint(new Vector3(oCamera.pixelWidth, 0, oCamera.nearClipPlane));

            var oEdge = gameObject.AddComponent<EdgeCollider2D>();
            var oEdgePoints = new[] { vBottomRight, vTopRight, vTopLeft, vBottomLeft, vBottomRight };
            oEdge.points = oEdgePoints;
        }
    }
}
