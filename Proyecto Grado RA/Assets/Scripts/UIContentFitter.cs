using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContentFitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
          
         
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fit()
    {
        HorizontalLayoutGroup hg = GetComponent<HorizontalLayoutGroup>();
        //Se calcula la cantidad de separaciones 
        int childCount = transform.childCount - 1;
        //Width de los Rectangle Estamos asumiendo que el Width de los Rectangle son lo mismo 
        float childWidth = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        float width = hg.spacing * childCount + childCount * childWidth + hg.padding.left + childWidth;

        Vector2 size = GetComponent<RectTransform>().sizeDelta;
        GetComponent<RectTransform>().sizeDelta = new Vector2(width, 183);
    }
}
/*HorizontalLayoutGroup hg = GetComponent<HorizontalLayoutGroup>();
         //Se calcula la cantidad de separaciones 
         int childCount = transform.childCount - 1;
         //Width de los Rectangle Estamos asumiendo que el Width de los Rectangle son lo mismo 
         float childWidth = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
         float width = hg.spacing * childCount + childCount * childWidth + hg.padding.left;
  
         GetComponent<RectTransform>().sizeDelta = new Vector2(width, 183);*/