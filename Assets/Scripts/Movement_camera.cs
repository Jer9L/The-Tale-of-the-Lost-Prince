using UnityEngine;

public class Movement_camera : MonoBehaviour
{
    public Transform plTransform;
    public Vector3 offset;
    public float smoothSpeed = 0.7f;

    private void LateUpdate()
    {
        Vector3 desiredPosition = plTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

}
