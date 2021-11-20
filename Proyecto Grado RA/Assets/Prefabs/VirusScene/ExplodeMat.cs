using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeMat : MonoBehaviour
{
    public GameObject explosion;
    
    public GameObject enemyToSpawnTos;
    public GameObject enemyToSpawnNaus;
    public GameObject enemyToSpawnNeum;
    
    private Vector3 killPos;
    private Quaternion killRot;
    public float waitTime = 3.0f;

    private int aux;
    
    private bool bulletCollission = false; // evitar golpear varios virus con una sola plantabullet

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Tos" && bulletCollission == false)
        {
            Destroy(collision.transform.gameObject);
            Scoring.scoreMat += 1;
            
            bulletCollission = true;
            
            killPos = collision.transform.position;
            killRot = collision.transform.rotation;
            aux = 3;
            StartCoroutine(SpawnEnemyAgain());
            
            // Destroy(Instantiate(explosion, collision.transform.position, collision.transform.rotation));
            Destroy(Instantiate(explosion, collision.transform.position, collision.transform.rotation),waitTime);
            
        }
        
        if (collision.transform.tag == "Nauseas" && bulletCollission == false)
        {
            Destroy(collision.transform.gameObject);
            Scoring.scoreWir += 1;
            bulletCollission = true;
            
            killPos = collision.transform.position;
            killRot = collision.transform.rotation;
            aux = 5;
            StartCoroutine(SpawnEnemyAgain());
            
            //  Destroy(Instantiate(explosion, collision.transform.position, collision.transform.rotation));
            Destroy(Instantiate(explosion, collision.transform.position, collision.transform.rotation),waitTime);
        }
        
        if (collision.transform.tag == "Neumonia" && bulletCollission == false)
        {
            Destroy(collision.transform.gameObject);
            Scoring.scoreWir += 1;
            bulletCollission = true;
            
            killPos = collision.transform.position;
            killRot = collision.transform.rotation;
            aux = 6;
            StartCoroutine(SpawnEnemyAgain());
            
            //  Destroy(Instantiate(explosion, collision.transform.position, collision.transform.rotation));
            Destroy(Instantiate(explosion, collision.transform.position, collision.transform.rotation),waitTime);
        }
    }

    IEnumerator SpawnEnemyAgain()
    {
        yield return new WaitForSeconds(waitTime);
        if (aux == 3)
        {
            Instantiate(enemyToSpawnTos, killPos, killRot);
            bulletCollission = false;
            Destroy(gameObject); //destruye bulletplanta    
        }
        if (aux == 5)
        {
            Instantiate(enemyToSpawnNaus, killPos, killRot);
            bulletCollission = false;
            Destroy(gameObject); //destruye bulletplanta    
        }
        if (aux == 6)
        {
            Instantiate(enemyToSpawnNeum, killPos, killRot);
            bulletCollission = false;
            Destroy(gameObject); //destruye bulletplanta    
        }
    }
}
