using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{
   // [SerializeField] private GameObject arObj;
    [SerializeField] public Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;

    List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = arCam.ScreenPointToRay(Input.mousePosition);  //Presionand la pantalla del telefono donde se originara el objeto
            if (_raycastManager.Raycast(ray, _hits))
            {
                Pose pose = _hits[0].pose;            //Pose da la posicion del objeto particular
                Instantiate(DataHandler.Instance.plant, pose.position, pose.rotation);
            }
        }
    }
}
