using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


//Colocar y manipular
public class SpawnableManager : MonoBehaviour
{
    //Clave para manejo del resto del juego e instanciacion
    [SerializeField] private GameObject spawnableLevel;
    
    private GameObject  spawnedObject;
    
    // Start is called before the first frame update
    void Start()
    {
      //  spawnedObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Metodo que toma la ubicacion y crea una instancia del prefab
    public GameObject SpawnPrefab()
    {
        spawnedObject = spawnableLevel;
        return spawnedObject;
        //spawnedObject = Instantiate(spawnableLevel, spawnPosition, Quaternion.identity);
    }
}
