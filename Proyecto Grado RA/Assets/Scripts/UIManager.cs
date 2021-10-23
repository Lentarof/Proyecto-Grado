using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private GraphicRaycaster raycaster;
    
    //Por el POinterEventData se necesita el EventSystem
    private PointerEventData pData;
    private EventSystem eventSystem;

    //Es el centro del slidescroll
    public Transform selectionPoint;

    public static UIManager instance;
    //Lo mismo que el datahandler aunque se puede mover e instanciarlo
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Esto es el componente graphic raycaster del canvas
        raycaster = GetComponent<GraphicRaycaster>();
        //Con referente al Canvas system ya que tambien tiene su EventSystem
        eventSystem = GetComponent<EventSystem>();
        //creado por el eventSystem el pData
        pData = new PointerEventData(eventSystem);

        //Toma la posicion central SelectionPoint 
        pData.position = selectionPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Metodo por el cual pasaremos el boton y verificaremos si esta siendo presionado por el raycast
    public bool OnEntered (GameObject button)
    {
        //Lista creada de Raycast
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pData, results);

        
        foreach (RaycastResult result  in results)
        {
            //podemos buscar a traves de la lista si el resultado es el boton
            if (result.gameObject == button )
            {
                return true;
            }
        }
        return false;
    }

}
