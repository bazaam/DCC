using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 6.0F;
    public float gravity = 20.0F;
    GameObject spawnPoint;

    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;

    void Awake()
    {
       
    }
    void Start()
    {
        // Store reference to attached component
        //controller = GetComponent<CharacterController>();

        
    }
   
    void Update()
    {
        //SceneManager.sceneLoaded += SetSpawn;

        // Character is on ground (built-in functionality of Character Controller)
        if (controller.isGrounded)
        {
            // Use input up and down for direction, multiplied by speed
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        // Apply gravity manually.
        moveDirection.y -= gravity * Time.deltaTime;
        // Move Character Controller
        controller.Move(moveDirection * Time.deltaTime);
    }

    
    public void SetLocation(Vector2 vector2)
    {

        Vector3 newLocation = new Vector3(vector2.x, 0, vector2.y);
        transform.position = newLocation;

        Debug.Log("Player set to new location");
        
    }


}