using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private Rigidbody playerRigidBody;

    private float gravityModifier = 1f;
    private float limY = 14f;
    private float limDownY = 0f;

    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;

    private float topLimit = 2f;

    public float jumpForce = 50;

    public ParticleSystem explosionParticleSystem;

    public bool gameOver = false;

    public AudioClip jumpClip;
    public AudioClip explosionClip;




    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        playerAudioSource = GetComponent<AudioSource>();

        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        cameraAudioSource.volume = 0.5f;
    }




    void Update()
    {
        if (transform.position.y >= limY)
        {
            transform.position = new Vector3(transform.position.x, limY,
                transform.position.z);
            playerRigidBody.AddForce(Vector3.down * topLimit, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudioSource.PlayOneShot(jumpClip, 1f);
        }

        if (transform.position.y <= limDownY && !gameOver)
        {
            gameOver = true;
            explosionParticleSystem.Play();
            playerAudioSource.PlayOneShot(explosionClip, 1);
            cameraAudioSource.volume = 0.05f;
        }
        
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {           
            if (otherCollider.gameObject.CompareTag("Bomb"))
            {

                gameOver = true;
                explosionParticleSystem.Play();

                // audio
                cameraAudioSource.volume = 0.05f;
                playerAudioSource.PlayOneShot(explosionClip, 0.4f);

            }
        }
    }
}
