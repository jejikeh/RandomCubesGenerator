using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class RotateCameraAroundObject : MonoBehaviour
{

    [SerializeField] private float _cameraSensivity;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _cameraSmooth;
    [SerializeField] private float _distanceToTarget;

    private Vector2 _cameraRotation;
    private Vector3 _currentCameraRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X")) * _cameraSensivity;
        
        if (Input.GetMouseButton(2) || Input.GetKey(KeyCode.LeftAlt))
        {

            _cameraRotation += mouseInput;

        }

        if(Input.mouseScrollDelta.y > 0)
        {
            _distanceToTarget += 0.1f;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            _distanceToTarget -= 0.1f;
        }
        Vector3 nextRotation = new Vector3(_cameraRotation.x, _cameraRotation.y);
        _currentCameraRotation = Vector3.SmoothDamp(_currentCameraRotation, nextRotation, ref _smoothVelocity, _cameraSmooth);
        transform.localEulerAngles = _currentCameraRotation;
        transform.position = _targetTransform.position - transform.forward * _distanceToTarget;
    }
}
