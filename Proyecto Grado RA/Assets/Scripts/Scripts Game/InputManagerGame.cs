using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class InputManagerGame : MonoBehaviour
{
   // [SerializeField] public Camera arCam;
    private Camera arCam; 
   [SerializeField] private ARRaycastManager _raycastManager;
    
    private GameObject crosshair; 
   List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    
    private Touch touch;
    private Pose pose;
   
    private SpawnableManager _spawnableManager = new SpawnableManager();
   
    
    // Start is called before the first frame update
    void Start()
    {
     //   arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairCalculation();

        touch = Input.GetTouch(0);
        
        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
            return;
        
        if (IsPointerOverUI(touch)) return;

          
         Ray ray = arCam.ScreenPointToRay(touch.position);  //Presionand la pantalla del telefono donde se originara el objeto
         if (_raycastManager.Raycast(ray, _hits))
         {
            Pose pose = _hits[0].pose;            //Pose da la posicion del objeto particular
            Instantiate(_spawnableManager.SpawnPrefab(), pose.position, pose.rotation);
            _spawnableManager = null;
            // Instantiate(_spawnableManager.SpawnPrefab(spawnPosition), pose.position, pose.rotation);
         }

        //  Instantiate(DataHandler.Instance.GetPlant(), pose.position, pose.rotation);
        //*/
    }
    public bool IsPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
       // eventData.position = new Vector2(touch.startPosition.x, touch.startPosition.y);   //Todo esto con referente a la pantalla en donde presionamos
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
    void CrosshairCalculation() 
    {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
           Ray ray = arCam.ScreenPointToRay(origin);  //Presionand la pantalla del telefono donde se originara el objeto donde el VIewportToScreen toma las medidas centrales de la pantalla
        //El crosshair tiene que seguir el ray donde se presione al suelo
        if (_raycastManager.Raycast(ray, _hits))
      //  if (GestureTransformationUtility.Raycast(origin, _hits, TrackableType.PlaneWithinPolygon))
        {
            pose = _hits[0].pose;            //Pose da la posicion del objeto particular
            crosshair.transform.position = pose.position;   //posicion del crosshair y tambien necesitas crear la rotacion porque es horizontal
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0); //asi se alinea al piso
        }
    }
}
