using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover_RB : MonoBehaviour
{

    
    [SerializeField] Transform groundCheck; // földönállás a zuhanáshoz PIPA
    [SerializeField] float speed;
    [SerializeField] float fallSpeed;

    Rigidbody myRB; // elsõ a mozgás. PIPA

    public LayerMask groundMask;

    public float crouchSize;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();




    }

    // Update is called once per frame
    void Update()
    {
        MovedByRB();
        Crouch();
       

    }

    void MovedByRB()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = transform.forward * z + transform.right * x;
        direction.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            direction *= speed / 3f;


        }
        else if (Input.GetKey(KeyCode.LeftAlt))
        {

            direction *= speed * 1.7f;

        }
        else { direction *= speed; }


        //esés:
        Vector3 fall = transform.up; //negatív legyen
        fall.Normalize();
        
        bool standing = Physics.CheckSphere(groundCheck.position, 0.3f, groundMask);
        if (standing)
        {
            fall *= -1;

        }
        else 
        {
            fall *= fallSpeed;
        }

        myRB.velocity = direction + fall; 



    }


    

    void Crouch()
    {
        Vector3 originalSize = new Vector3(1,1,1); 
        Vector3 crouchSize = new Vector3(1, this.crouchSize, 1);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("Crouch");
            transform.localScale = crouchSize;

        }
        else
        {

            Debug.Log("noCrouch");
            transform.localScale = originalSize;
        
        }
    
    }


}
