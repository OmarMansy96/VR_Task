using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsSystem : MonoBehaviour
{
    public GameObject[] targetPrefabs; 
    public Transform[] spawnPoints;  
    public float spawnInterval = 2f; 
    public float hideTarget;
    GameModes gameMode;

    void Start()
    {
        gameMode=FindObjectOfType<GameModes>();
        StartCoroutine(SpawnTargets());
    }

    IEnumerator SpawnTargets()
    {
        while (true)
        {
            if (gameMode.isGameRunning)
            {
                SpawnTarget();
                yield return new WaitForSeconds(spawnInterval);
            }
           
        }
       
    }

    void SpawnTarget()
    {
        //if (GameModes.isGameRunning==false) return;
    
        int randomIndex = Random.Range(0, targetPrefabs.Length);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);


        GameObject newTarget = Instantiate(targetPrefabs[randomIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity);
        Destroy(newTarget, hideTarget);
        //Destroy(Instantiate(targetPrefabs[randomIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity), hideTarget);


    }

}
