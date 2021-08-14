using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class will zoom in (lerp) the camera, upon clicking a specific car part.
/// It will be attached to the the "Camera Controller" GameObject.
/// </summary>
public class CameraController : MonoBehaviour
{
    // Configs
    [SerializeField] float desiredDuration = 2f;
    [SerializeField] Text partsDescriptions;

    // States
    public bool _lerp;
    public bool _resetButtonClicked = true;
    
    // Cache
    Camera _mainCamera;
    Vector3 _cameraStartPosition;
    Vector3 _cameraCurrentPosition;
    Vector3 _cameraTargetPosition;
    float _elapsedTime;
    float _percentageComplete;

    
    private void Start()
    {
        _mainCamera = Camera.main;
        _cameraStartPosition = _mainCamera.transform.position;
    }
    
    
    private void Update()
    {
        SelectedPartInfo();
    }


    // Gets the '_endPosition' coordinates, depending on which car part was selected --> then moves the camera to that location.
    // And Updates the Label Text
    private void SelectedPartInfo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    CameraDestination cameraDestination = hit.transform.GetComponent<CameraDestination>();
                    Description partDescription = hit.transform.GetComponent<Description>();
                    if (cameraDestination && _resetButtonClicked)
                    {
                        _lerp = true;
                        _cameraTargetPosition = cameraDestination.GetEndPosition();
                        partsDescriptions.GetComponent<Text>().text = partDescription.GetDescription();
                    }
                }
            }
        }

        CameraZoom(_cameraTargetPosition);
    }

    
    // Zooms in the camera on selected car part
     public void CameraZoom(Vector3 endPosition)
     {
         if (_lerp)
         {
             _elapsedTime += Time.deltaTime;
             _percentageComplete = _elapsedTime / desiredDuration;
         
             _mainCamera.transform.position = Vector3.Lerp(_cameraStartPosition, endPosition,
                 Mathf.SmoothStep(0, 1, _percentageComplete));
             _resetButtonClicked = false;
         }
         _cameraCurrentPosition = _mainCamera.transform.position;
     }
     
    // Resets the Camera's position 
     public void ResetCamera()
     {
         _resetButtonClicked = true;
         _elapsedTime = 0;
         _mainCamera.transform.position = _cameraStartPosition;
         _lerp = false;
         partsDescriptions.GetComponent<Text>().text = "";
     }
}

