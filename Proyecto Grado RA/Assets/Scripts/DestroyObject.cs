using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class DestroyObject : MonoBehaviour
{
    private string tagPlantDestroy = "PlantGallery";
    public void DestroyGameObject()
    { 
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tagPlantDestroy);
        foreach (GameObject targets in taggedObjects)
        {
            Destroy(targets);
            
        }
    }
       /*public void DestroyGameObject(ARSelectionInteractable selected)
       {
          // Destroy(DataHandler.Instance.GetPlant());
          if (selected != null)
          {
              Destroy(selected);
          }
       }
       */
}
