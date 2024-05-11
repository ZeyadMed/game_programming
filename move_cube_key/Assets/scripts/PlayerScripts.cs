using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;

    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public bool isOnGround = true;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal"); // Changed forwardInput to Input
        forwardInput = Input.GetAxis("Vertical"); // Changed forwardInput to Input

        // Move the player forward and sideways
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Let the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) // Changed forwardInput to Input
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Changed forwardInput to ForceMode.Impulse
            //isOnGround = false;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnGround = true;
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.CompareTag("Vectory"))
        // {
        //     Debug.Log("Triggered by Enemy");
        //     transform.localScale -= new Vector3(10f, 10f, 10f);
        //     // Destroy(other.gameObject);
        // }
        //Check to see if the tag on the collider is equal to Enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Triggered by Enemy");
            //transform.localScale += new Vector3(10f * Time.deltaTime, 10f * Time.deltaTime, 10f * Time.deltaTime);

            explode();
            //Destroy(other.gameObject);
        }


    }

    public void explode()
    {
        gameObject.SetActive(false);
        for (int x = 0; x < cubesInRow; x++)
        {

            for (int y = 0; y < cubesInRow; y++)
            {

                for (int z = 0; z < cubesInRow; z++)
                {

                    createPiece(x, y, z);

                }
            }
        }
    }
    void createPiece(int x, int y, int z)
    {
        {
            GameObject piece;
            piece = GameObject.CreatePrimitive(PrimitiveType.Capsule);

            piece.transform.position = transform.position;
            piece.transform.localScale = new Vector3(cubeSize * x, cubeSize * y, cubeSize * z);

            piece.AddComponent<Rigidbody>();
            piece.GetComponent<Rigidbody>().mass = cubeSize;
            sound();
        }
    }

    void sound()
    {
        src.clip = sfx3;
        src.Play();
    }

}





/**

void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            temp += new Vector3(10f * Time.deltaTime, 10f * Time.deltaTime, 10f * Time.deltaTime);


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

*/