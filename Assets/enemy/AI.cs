
using UnityEngine;

public class AI : MonoBehaviour
{
    
   

    // Protocoll White
   public Vector3 startPos;
    Vector3 ownPos;
    Vector3 vectorStart;
    Vector3 vectorCheckpointI;
    Vector3 vectorCheckpointII;

    public bool checkpointStart_reached;
    public bool checkpointI_reached;
    public bool checkpointII_reached;

    [SerializeField] float speed;
    float pursuit;
    float acc;

    //Protocol Red (min: transform.position, max: t.p + 10,0,10)
    Vector3 borderPositive;
    Vector3 borderNegative;
    
    public bool redCode;


    //ProtocolYellow:
    public bool yellowCode;

    private void Start()
    {
       

        pursuit = 4 * Time.deltaTime;
        acc = speed  * Time.deltaTime;
        checkpointStart_reached = true;

        startPos = transform.position;
        ownPos = startPos;
        vectorStart = startPos;
        vectorCheckpointI = transform.position + new Vector3(0,0,10); 
        vectorCheckpointII = transform.position + new Vector3(10,0,0);   





    }


    void Update()
    {
       
        ProtocolWhite();              
    }



    void ProtocolYellow()
    {   

        if (yellowCode)
        {

            Debug.Log("Back");
           transform.position = Vector3.MoveTowards(transform.position, startPos, acc);
           transform.rotation = Quaternion.LookRotation(vectorStart - transform.position);

            if (transform.position == vectorStart)
            { 
                checkpointStart_reached = true;
                yellowCode = false;
            } 
        }


        
    
    }

    void ProtocolRed()
    {

        if (redCode)
        {

           
            checkpointStart_reached = false;
            checkpointI_reached = false;
            checkpointII_reached = false;
           // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, pursuit);


            //yellowCode = (player.transform.transform.position - transform.position).magnitude > 7 ? true : false;
            redCode = yellowCode ? false : true;
           

        }

    }

    void ProtocolWhite()
    {


        Rotate();
        FirstCheckpoint();   
        SecondCheckpoint();
        StartCheckpoint();

        /*
        if ((transform.position - player.transform.position).magnitude <= 7)
        {          redCode = true;      }
        */
    }

    void Rotate()

    {   Vector3 direction = new Vector3();

        if(checkpointStart_reached)
        direction = vectorCheckpointI - transform.position;

        if(checkpointI_reached)
        direction = vectorCheckpointII - transform.position;
        
        if(checkpointII_reached)
        direction = vectorStart - transform.position;

      // if (redCode)
        //direction = player.transform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(direction);
    }
    void FirstCheckpoint()
    {
        if (checkpointStart_reached)
        { 
            transform.position = Vector3.MoveTowards(transform.position, vectorCheckpointI, acc );

              if (transform.position == vectorCheckpointI) // one
              {
                Debug.Log("1 checkpoint");
                checkpointI_reached = true;

                checkpointStart_reached = false;


                

                transform.rotation = Quaternion.LookRotation(vectorCheckpointII);
              }                       
        }
       
    }

   void SecondCheckpoint()
    {
        if (checkpointI_reached)
        {
            transform.position = Vector3.MoveTowards(transform.position, vectorCheckpointII, acc);

            if (transform.position == vectorCheckpointII) // two
            {
                Debug.Log("2 checkpoint");
                checkpointII_reached = true;

                checkpointI_reached = false;

                transform.rotation = Quaternion.LookRotation(vectorStart);

            }
        }

   }

    void StartCheckpoint()
    {
        if (checkpointII_reached)
        {
            transform.position = Vector3.MoveTowards(transform.position, vectorStart, acc);

            if (transform.position == vectorStart)
            {
                Debug.Log("Start/Finish checkpoint");
                checkpointStart_reached = true;    
              
                checkpointII_reached = false;

                transform.rotation = Quaternion.LookRotation(vectorCheckpointI);
            }
        }



    }

    

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
         {
            Debug.Log("Attacking");
          //  player.GetHurt(3);
        
        
        }


    }




}

