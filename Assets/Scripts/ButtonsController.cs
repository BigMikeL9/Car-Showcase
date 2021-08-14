using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class will zoom in (transform) the camera, upon clicking the corresponding car part button.
/// It will be attached to each button.
/// </summary>
public class ButtonsController : MonoBehaviour
{
    
    // Configs
    [SerializeField] GameObject carPart;
    [SerializeField] Text partsDescriptions;
    
    // Cache
    Camera _mainCamera;
    CameraController _cameraController;
    Vector3 _cameraStartPosition;
    Button _button;
    
    
    
    private void Start()
    {
        _mainCamera = Camera.main;
        _cameraStartPosition = _mainCamera.transform.position;
        
        _button = GetComponent<Button>();
        _button.onClick.AddListener(MoveCamera);

        _cameraController = FindObjectOfType<CameraController>();
    }

    
    // Transforms camera position and updates the Label Text.
    private void MoveCamera()
    {
        CameraDestination cameraDestination = carPart.GetComponent<CameraDestination>();
        Description partDescription = carPart.GetComponent<Description>();
        if (cameraDestination && _cameraController._resetButtonClicked)
        {
            _mainCamera.transform.position = cameraDestination.GetEndPosition();
            partsDescriptions.GetComponent<Text>().text = partDescription.GetDescription();
        }
    }
}
