using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will be used to write the labels for the parts.
/// It will be attached to each car part gameObject.
/// </summary>
public class Description : MonoBehaviour
{
    [TextArea(4,6)] [SerializeField] string description;

    // This method will be used to access the description of each car part.
    public string GetDescription()
    {
        return (description);
    }
}
