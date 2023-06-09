
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController playerCC;
    public float speed;
    [Space]
    public float fallingSpeed;
    Vector3 velocity;
    public Transform groundChecker;
    public LayerMask groundMask;
    bool grounded;
    [Space]
    //jmp:
    public float jumpHeight;

    [Space]
    //crouch:
    public float crouchSize;
    public Transform roofChecker;
   

  
   
    void Update()
    {

        MovingCC();
        Falling();
        Jump();
        Crouch(); 

       


    }

  
    void MovingCC()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        move.Normalize();

        //walk
        if (Input.GetKey(KeyCode.Tab))
        {

            move *= speed / 2f;

        }
        else if (Input.GetKey(KeyCode.LeftShift)) //run
        {

            move *= speed * 1.6f;

        }
        else { move *= speed; }



        // move
        playerCC.Move(move * Time.deltaTime);



    }

    void Falling()
    {
        grounded = Physics.CheckSphere(groundChecker.position, 0.4f, groundMask);

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }
        else
        { 
         velocity.y += fallingSpeed * Time.deltaTime;
        }


        playerCC.Move(velocity * Time.deltaTime);
    
    }

    void Jump()
    {
       if (Input.GetButtonDown("Jump") && grounded)
       {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * fallingSpeed);
               
       }
    
    }

    void Crouch()
    {
        Vector3 originalSize = new Vector3(1,1,1);
        Vector3 crouchSize = new Vector3(1, this.crouchSize, 1 );
   
        bool roof = Physics.CheckSphere(roofChecker.position, 0.4f, groundMask);

        if (Input.GetKey(KeyCode.C))
        {
            transform.localScale = crouchSize;

        }
        else if (roof && transform.localScale.y == 1)
        {

            transform.localScale = originalSize;

        }
        else if (roof)
        { 
            transform.localScale = crouchSize;
        
        }
        else { transform.localScale = originalSize; }

    

    }


   

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody otherRB = hit.collider.attachedRigidbody;

        if (otherRB != null)
        { 
        Vector3 direction = hit.gameObject.transform.position - transform.position;
            direction.Normalize();
            otherRB.AddForce(direction * speed /3f, ForceMode.Impulse);


        }
     
    }

  

    private void OnDrawGizmos()
    {


        Gizmos.color = Color.red;
        Gizmos.DrawSphere(roofChecker.position, 0.4f);
    }



    

}

