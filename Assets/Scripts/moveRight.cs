using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRight : MonoBehaviour
{
    private float limR = 30f;
    public float speed = 10f;
    private playerController playerControllerScript;


    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();
    }

    void Update()
    {
        if (!playerControllerScript.gameOver) 
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (transform.position.x >limR)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -limR)
        {
            Destroy(gameObject);
        }

    }
   
}
