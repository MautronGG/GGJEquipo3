using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] float _rotationSpeed;
    float _horizontalInput;

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        if (Input.GetAxis("Mouse X") != 0)
        {
            _horizontalInput = Input.GetAxis("Mouse X");
            //_camera.transform.rotation += Quaternion.Euler(new Vector3(_horizontalInput,0,0) * _rotationSpeed * Time.deltaTime);
        }
    }
}
