using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public static new Camera camera = Camera.main;
    public static float height = camera.orthographicSize;
    public static float width = height * camera.aspect;
}
