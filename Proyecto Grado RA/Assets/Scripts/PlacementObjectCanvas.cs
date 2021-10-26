using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class PlacementObjectCanvas : MonoBehaviour
{
    [SerializeField] private Canvas canvasComponent;

  //  [SerializeField] private bool displayCanvas = true;

    private ARSelectionInteractable selected = new ARSelectionInteractable();
    
    //public bool IsSelected { get; set; }
    public void ToggleCanvas()
    {
        
        canvasComponent?.gameObject.SetActive(true);
       
    }
    
}

