using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeManz : MonoBehaviour
{
    public GameObject explosion;

    public GameObject enemyToSpawnGrip;
    
    private Vector3 killPos;
    private Quaternion killRot;
    public float waitTime = 3.0f;

    private int aux;
    
    private bool bulletCollission = false; // evitar golpear varios virus con una sola plantabullet

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Gripe" && bulletCollission == false)
        {
            Destroy(collision.transform.gameObject);
            Scoring.scoreWir += 1;
            bulletCollission = true;
            
            killPos = collision.transform.position;
            killRot = collision.transform.rotation;
            aux = 4;
            StartCoroutine(SpawnEnemyAgain());
            
            //Destroy(Instantiate(explosion, collision.transform.position, collision.transform.rotation));
            Destroy(Instantiate(explosion, collision.transform.position, collision.transform.rotation),waitTime);
        }
    }

    IEnumerator SpawnEnemyAgain()
    {
        yield return new WaitForSeconds(waitTime);
        if (aux == 4)
        {
            Instantiate(enemyToSpawnGrip, killPos, killRot);
            bulletCollission = false;
            Destroy(gameObject); //destruye bulletplanta    
        }
    }
   
}
