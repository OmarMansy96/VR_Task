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
        gameMode = FindObjectOfType<GameModes>();
        StartCoroutine(SpawnTargets());
    }

    IEnumerator SpawnTargets()
    {
        while (true)
        {

            SpawnTarget();
            yield return new WaitForSeconds(spawnInterval);


        }

    }

    void SpawnTarget()
    {

        int randomIndex = Random.Range(0, targetPrefabs.Length);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        print("before");
        if (gameMode.isGameRunning == false) return;

        print("after");
        GameObject newTarget = Instantiate(targetPrefabs[randomIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity);
        Destroy(newTarget, hideTarget);
        //Destroy(Instantiate(targetPrefabs[randomIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity), hideTarget);


    }

}
