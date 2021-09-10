using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    private Button btn;
    public GameObject plant;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectObject() 
    {   //Cuando clickeemos el boton
        //Es aca donde se cambiar la variable arObj que esta en InputManager

        DataHandler.Instance.plant = plant;
    }
}
