using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float speed = 0.5f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 disiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, disiredPosition, speed);
        smoothPosition.y = 0;
        transform.position = smoothPosition;    
    }
}
