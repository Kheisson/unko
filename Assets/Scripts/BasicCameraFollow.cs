using UnityEngine;
using System.Collections;

public class BasicCameraFollow : MonoBehaviour 
{

    public Transform followPosition;
    public float smoothSpeed;
    private Vector3 _destPosition;


    private void LateUpdate()
    {
        if (followPosition != null)
            _destPosition = new Vector3(followPosition.position.x, followPosition.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, _destPosition, smoothSpeed);
    }
}

