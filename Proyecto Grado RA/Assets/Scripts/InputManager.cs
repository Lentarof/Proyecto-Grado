using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.AR;


public class InputManager : ARBaseGestureInteractable
{
   // [SerializeField] private GameObject arObj;
    [SerializeField] public Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;

    [SerializeField] private GameObject crosshair;

    List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private Touch touch;
    private Pose pose;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Metodo que indica cuando la persona puede hacer un TAP en el plano
    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        //Permitir que la persona coloque un objeto si GESTURE no tenga ningun objeto
        //Targetobject deprecated
        if (gesture.targetObject == null)
            return true;
        return false;
    }
    
    //Metodo que indicara donde colocaremos el objeto
    protected override void OnEndManipulation(TapGesture gesture)
    {
        //Verificamos si el gesture fue cancelado
        //WasCancelled deprecated
        if (gesture.isCanceled)
            return;
        if (gesture.targetObject != null || IsPointerOverUI(gesture))
        {
            return;
        }
        //si ninguno de los anteriores es verdadero
                                                //Saber donde la persona esta clickeando en la pantalla
        if (GestureTransformationUtility.Raycast(gesture.startPosition, _hits, TrackableType.PlaneWithinPolygon))
        {
            //Obtenemos el POSE de Crosshair y con eso podemos colocar el objeto
            GameObject placedObj = Instantiate(original: DataHandler.Instance.GetPlant(), pose.position, pose.rotation);
            
            //Asegurarnos que el objeto tiene un ancla de colocacion
            //eso ayudara a encontrar la posicion correspondiente de los objetos en el world space
            var anchorObject = new GameObject("PlacementAnchor");
                                            //en pose esta nuestro hit information
            anchorObject.transform.position = pose.position;
            anchorObject.transform.rotation = pose.rotation;
            //Anchor sera el padre y sera el que mantendra el placedObject 
            // Asi es como haremos un Track al PLACEDOBJ nos fijaremos en el anchor y donde sea que este el anchor
            //nuestro PLACEDOBJ objeto estara en el mismo lugar
            placedObj.transform.parent = anchorObject.transform;
        }
    }


    void FixedUpdate()
    {
        CrosshairCalculation();
    }

    // Update is called once per frame
    void Update()
    {
      /*  CrosshairCalculation();

        touch = Input.GetTouch(0);
        
        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
            return;

        if (IsPointerOverUI(touch)) return;

        /* Ray ray = arCam.ScreenPointToRay(touch.position);  //Presionand la pantalla del telefono donde se originara el objeto
         if (_raycastManager.Raycast(ray, _hits))
         {
            Pose pose = _hits[0].pose;            //Pose da la posicion del objeto particular
            Instantiate(DataHandler.Instance.plant, pose.position, pose.rotation);
         }*/

      //  Instantiate(DataHandler.Instance.GetPlant(), pose.position, pose.rotation);
      //*/
    }

    //TAPGESTURE viene del ARTOOLKIT INTERACTABLE y lo utilizaremos en vez del TOUCH aparte que da mas opcion ver
    //si es un TAP un SWIPE ya viene con los calculos correspondientes asi que evtiamos esa parte
   // bool IsPointerOverUI(Touch touch)
   bool IsPointerOverUI(TapGesture touch)
   {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        //eventData.position = new Vector2(touch.position.x, touch.position.y);
        eventData.position = new Vector2(touch.startPosition.x, touch.startPosition.y);   //Todo esto con referente a la pantalla en donde presionamos
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
    
    //messure AR para tener exactitud al momento de colocar el objeto, en donde colocar el crosshair
    void CrosshairCalculation() 
    {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
     //   Ray ray = arCam.ScreenPointToRay(origin);  //Presionand la pantalla del telefono donde se originara el objeto donde el VIewportToScreen toma las medidas centrales de la pantalla
                                                    //El crosshair tiene que seguir el ray donde se presione al suelo
        //if (_raycastManager.Raycast(ray, _hits))
        if (GestureTransformationUtility.Raycast(origin, _hits, TrackableType.PlaneWithinPolygon))
        {
            pose = _hits[0].pose;            //Pose da la posicion del objeto particular
            crosshair.transform.position = pose.position;   //posicion del crosshair y tambien necesitas crear la rotacion porque es horizontal
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0); //asi se alinea al piso
        }
    }
}
