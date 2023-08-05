using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed, focusSpeed;
    [SerializeField] Rigidbody2D rBody;
    [SerializeField] GameObject shootPoint, bullet;

    private float currentSpeed;

    private float horizontalInput;
    private float verticalInput;



    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.position = new Vector2(0, 0);
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        //Vector2 movement = new Vector2(horizontalInput, verticalInput);

        if(Input.GetKey("left shift"))
        {
            currentSpeed = focusSpeed;
        } 
        else
        {
            currentSpeed = speed;
        }

        rBody.velocity = new Vector2(horizontalInput * currentSpeed, verticalInput * currentSpeed);
        Debug.Log("current speed: " + currentSpeed);

        Shoot();
    }

    void PlayerMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Debug.Log(horizontalInput + "," + verticalInput);

    }

    void Shoot()
    {
        if (Input.GetKeyDown("z"))
        {
            Debug.Log("haha shoot");
            Instantiate(bullet, shootPoint.transform.position, bullet.transform.rotation);
        }
    }
}
