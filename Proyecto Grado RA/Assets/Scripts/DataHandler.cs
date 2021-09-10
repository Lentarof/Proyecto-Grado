using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public GameObject plant;

    private static DataHandler instance;

    //Se usa un singleton pattern code por el facil acceso al dato
    public static DataHandler Instance 
    {
        get 
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        } 
    }
}
