using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawnManager : MonoBehaviour
{
    private float startDelay = 2.0f;
    private float repeatRate = 1.5f;
    private float limY = 14f;
    private float randomY;

    private Vector3 spawnPosL;
    private Vector3 spawnPosR;
    private playerController playerControllerScript;

    public GameObject[] obstaclePrefabs;




    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();

    }


    public void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            randomY = Random.Range(0, limY);
            spawnPosL = new Vector3(-20, randomY, 0);
            spawnPosR = new Vector3(20, randomY, 0);

            int randNum = Random.Range(0, 2);
            if (randNum == 0)
            {
                Instantiate(obstaclePrefabs[0], spawnPosL, obstaclePrefabs[0].transform.rotation);
            }
            if (randNum == 1)
            {
                Instantiate(obstaclePrefabs[1], spawnPosR, obstaclePrefabs[1].transform.rotation);
            }
        }

    }
}
