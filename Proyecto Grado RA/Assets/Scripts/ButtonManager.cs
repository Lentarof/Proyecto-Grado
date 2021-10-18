using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
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
        //si este boton a entrado al raycast lo vamos a escalar
        if (UIManager.Instance.OnEntered(gameObject))
        {
                                      //el primer valor es cuanto escalar el segundo es el valor de que tan rapido o lento quieres la animacion
            transform.DOScale(Vector3.one * 2, 0.3f);
            //transform.localScale = Vector3.one * 2;
        }
        else
        {
            transform.DOScale(Vector3.one, 0.3f);
            //transform.localScale = Vector3.one;
        }
    }

    void SelectObject() 
    {   //Cuando clickeemos el boton
        //Es aca donde se cambiar la variable arObj que esta en InputManager

        DataHandler.Instance.plant = plant;
    }
}
