using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This class will highlight car parts as you hover over their corresponding button.
/// It will be attached to each button.
/// </summary>
public class HoverButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Configs
    [Header("Car Part Highlight Configs")]
    [SerializeField] Color initialColor;
    [SerializeField] Color mouseOverColor;
    [SerializeField] Color mouseClickColor;
    [SerializeField] GameObject carPart;
    
    // Cache
    static string Color1 = "_Color";
   
    
    // Changes car part color as you hover over button
    public void OnPointerEnter(PointerEventData eventData)
    {
        carPart.GetComponent<Renderer>().material.SetColor(Color1, mouseOverColor);
    }
 
    // Returns car part color back to its initial value, when mouse is no longer over its corresponding button.
    public void OnPointerExit(PointerEventData eventData)
    {
        carPart.GetComponent<Renderer>().material.SetColor(Color1, initialColor);
    }
    
    // Changes car part color on click
    private void OnMouseDown()
    {
        carPart.GetComponent<Renderer>().material.SetColor(Color1, mouseClickColor);
    }

    // Returns car part color back to highlighted color, upon releasing left mouse button
    private void OnMouseUp()
    {
        carPart.GetComponent<Renderer>().material.SetColor(Color1, mouseOverColor);
    }
}
