using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] Rigidbody rb;

    public ParticleSystem exploreParticle;  
    public ManagerText managerText;
    
    private float limitX = 5;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();  
        managerText = GameObject.Find("Manager Text").GetComponent<ManagerText>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        this.rb.velocity = (Vector3.right * speed * horizontalInput);

        if (transform.position.x < -limitX)
        {
            transform.position = new Vector3(-limitX, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitX)
        {
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            exploreParticle.gameObject.SetActive(true);
            managerText.GameOver();
                     
            //gameObject.SetActive(false);
            //other.gameObject.SetActive(false);

            Debug.Log("Game Over!");
            isGameOver = true;
            
        }
    }
    public void RestarGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
