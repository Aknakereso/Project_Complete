
using UnityEngine;

public class ProjectileToPlayer : MonoBehaviour
{
     [SerializeField] GameObject frogMonster;
    AngleToPlayer  angleToPlayer;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public Transform player;
    private Vector3 playerPos;
    private Vector3 playerDir;

    public float angle;
    public int lastIndex;

    [Space]
    public float speed;
    float acc;
    float actionTime;
    private void Awake()
    {
        actionTime = Time.time;
    }



    void Start()
    {
        angleToPlayer = frogMonster.GetComponent<AngleToPlayer>();
        acc = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

        playerPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        playerDir = playerPos - transform.position;
        angle = Vector3.SignedAngle(playerDir, transform.forward, Vector3.up);



        lastIndex = GetIndex(angle);

        spriteRenderer.sprite = sprites[lastIndex];

      

    }

   


     int GetIndex(float angle)
     {

        if (angle > -45f && angle < 45f)
        {
            return 0;
        
        }
        if (angle >= 45f && angle < 135f)
        {
            return 1;
        
        }
        if (angle >= 135f || angle < -135f)
        {

            return 2;
        }
        if (angle <= -45f && angle >= -135f)
        {

            return 3;
        }

        return lastIndex;
    
     }


    private void OnCollisionEnter(Collision collision)
    {

       
        if (Time.time > actionTime + 0.2f)
        { 
             if (collision.gameObject.tag == "Player")
             {
              Debug.Log("talált");
              Destroy(gameObject);

             }
            else if (collision.gameObject.tag == "Untagged")
            {
                Destroy(gameObject);
            
            }
        
        }
        

    }
}
