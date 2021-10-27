using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


//Colocar y manipular
public class SpawnableManager : MonoBehaviour
{
    
    [SerializeField] private ARRaycastManager raycastManager;
    private List<ARRaycastHit> mhit = new List<ARRaycastHit>();
    //Clave para manejo del resto del juego e instanciacion
    [SerializeField] private GameObject spawnablePrefab;

    private Camera arCam;
    private GameObject spawnedObject;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 0)
            return;
        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);
        
        //Fase se encuentra el evento tactil
        if (raycastManager.Raycast(Input.GetTouch(0).position, mhit))
        {
            //Si la fase se establece en Began
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                //Comprobar si estamos tocando algun objeto generado anteriormente
                if (Physics.Raycast(ray, out hit))
                {
                    //Si es asi asignamos ese objeto a la variable spawnedObject
                    if (hit.collider.gameObject.tag == "Floor")
                    {
                        spawnedObject = hit.collider.gameObject;
                    }
                    else
                    {
                        SpawnPrefab(mhit[0].pose.position);
                    }
                }
            }//Si la fase se establece en Moved y la variable spawnedObject tiene algo moveremos a la ubicacion tactil en el plano
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = mhit[0].pose.position;
            }//Si la fase  Ended estableceremos la variable spawnedObject nula para ya no arrastrar el prefab
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }
        }
    }
    
    //Metodo que toma la ubicacion y crea una instancia del prefab
    public void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }
}
