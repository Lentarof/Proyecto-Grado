using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;

public class PlacementWithManySelectionController : MonoBehaviour
{
    [SerializeField] private Camera arCamera;

    [SerializeField] private PlacementObjectCanvas placeCanvas;

   // [SerializeField] private PlacementObject[] placedObjects;
    
    private Vector2 touchPosition = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
         //           PlacementObject placementObject= hitObject.transform.GetComponent<PlacementObject>();
           //         if (placementObject != null)
                    {
                   //     ChangeSelectedObject(placementObject);
                    }
                }
            }
        }
    }

    public void CanvasS()
    {
        placeCanvas.ToggleCanvas();
    }

   /* void ChangeSelectedObject(PlacementObject selected)
    {
        foreach (var current in placedObjects)
        {
            if (selected != current)
            {
                current.IsSelected = false;
            }
            else
            {
                current.IsSelected = true;
            }
        }
        
    }*/
}
