using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 10f;
    public Vector3 offset;

    private void Update()
    {
        Vector3 desiredPoistion = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPoistion, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
