using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will highlight car parts as you hover over them, to show they are clickable.
/// It will be attached to each car part.
/// </summary>

public class HoverParts : MonoBehaviour
{
   // Configs
   [Header("Car Part Highlight Configs")]
   [SerializeField] Color initialColor;
   [SerializeField] Color mouseOverColor;
   [SerializeField] Color mouseClickColor;
   
   
   // Cache
   static string Color1 = "_Color";
   Renderer _renderer;

   private void Start()
   {
      _renderer = GetComponent<Renderer>();
   }
   

   // Changes car part color as you hover over it
   private void OnMouseEnter()
   {
      _renderer.material.SetColor(Color1, mouseOverColor);
   }

   // Returns car part color back to its initial value, when mouse is no longer over it
   private void OnMouseExit()
   {
      _renderer.material.SetColor(Color1, initialColor);
   }

   // Changes car part color on click
   private void OnMouseDown()
   {
      _renderer.material.SetColor(Color1, mouseClickColor);
   }

   // Returns car part color back to highlighted color, upon releasing left mouse button
   private void OnMouseUp()
   {
      _renderer.material.SetColor(Color1, mouseOverColor);
   }
}
