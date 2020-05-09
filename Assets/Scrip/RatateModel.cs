using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatateModel : MonoBehaviour
{
    float rotationSpeed = 1f;

    private void OnMouseDrag()
    {
        float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
        //float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(Vector3.down, rotationX);
        //transform.Rotate(Vector3.right, rotationY);
    }
}
