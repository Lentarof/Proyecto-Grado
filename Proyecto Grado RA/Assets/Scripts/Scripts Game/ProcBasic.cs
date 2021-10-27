using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcBasic : MonoBehaviour
{
    [SerializeField] public GameObject[] PosGameObjects;

    [Range(0f, 1f)] public float prob = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0f, 1f) <= prob)
        {
            Instantiate(PosGameObjects[Random.Range(0,PosGameObjects.Length)],transform.position,Quaternion.Euler(Vector3.up*(Random.Range(0,4)*90))); 
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
