using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    
    public Transform arCamera;
 //   public GameObject projectile;
    
    public float shootForce = 700.0f;
   // private RaycastHit hit;

   public GameObject[] projectiles;

   private int modelIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // GameObject bullet = Instantiate( projectile, arCamera.position, arCamera.rotation) as GameObject;
            // bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);
            ARBulletObject(modelIndex);   
         
            /*  if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
              {
                  if (hit.transform.tag == "Tos")
                  {
                      Destroy(hit.transform.gameObject);
                      Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                      Destroy(explosion, 2f); //nothing gets left behind
                  } 
                  if (hit.transform.tag == "Gripe")
                  {
                      Destroy(hit.transform.gameObject);
                      Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                      Destroy(explosion, 2f);
                  }
                  if (hit.transform.tag == "Fiebre")
                  {
                      Destroy(hit.transform.gameObject);
                      Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                      Destroy(explosion, 2f);
                  } 
                  if (hit.transform.tag == "Neumonia")
                  {
                      Destroy(hit.transform.gameObject);
                      Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                      Destroy(explosion, 2f);       
                  }
                  if (hit.transform.tag == "Nauseas")
                  {
                      Destroy(hit.transform.gameObject);
                      Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                      Destroy(explosion, 2f);           
                  }
  
                  if (hit.transform.tag == "Germen")
                  {
                      Destroy(hit.transform.gameObject);
                      Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                      Destroy(explosion, 2f);
                  }
  
                  if (hit.transform.tag == "Rabbit")
                  {
                      //AGREGAR ALGO 
                      Destroy(hit.transform.gameObject);
                      Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                      Destroy(explosion, 2f);
                  }
              }*/
        }
    }

   public void ARBulletObject(int id)
    {
        for (int i = 0; i < projectiles.Length;  i++)
        {
            if (i == id)
            {
                GameObject clearUp = GameObject.FindGameObjectWithTag("PlantGame");
                Destroy(clearUp);

                GameObject bullets = Instantiate( projectiles[i], arCamera.position, arCamera.rotation) as GameObject;
                bullets.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);
            }
        }
    }

   public void ModelChangeRight()
   {
       if (modelIndex < projectiles.Length - 1)
           modelIndex++;
       else
           modelIndex = 0;
       ARBulletObject(modelIndex);
   }

   public void ModelChangeLeft()
   {
       if (modelIndex > 0)
           modelIndex--;
       else
           modelIndex = projectiles.Length-1;
       ARBulletObject(modelIndex);
   }

}
