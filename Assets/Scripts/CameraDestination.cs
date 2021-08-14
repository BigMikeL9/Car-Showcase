using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is attached to each car part.
/// It will feed the cameraTargetPosition coordinates, to the CameraController and ButtonsController classes.
/// </summary>
public class CameraDestination : MonoBehaviour
{
    [SerializeField] Vector3 endPosition;
    
    public Vector3 GetEndPosition()
    {
        return endPosition;
    }
}
