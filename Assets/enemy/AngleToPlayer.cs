
using UnityEngine;

public class AngleToPlayer : MonoBehaviour
{
    
   

    //temp:
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public Transform player;
    private Vector3 playerPos;
    private Vector3 playerDir;

    public float angle;
    public int lastIndex;

   

    
   

    void Start()
    { 
       
     
      //  player = FindObjectOfType<Placeholder>().transform;
        
    }

    
    void Update()
    {

                   
        playerPos = new Vector3(player.position.x, transform.position.y, player.position.z); // player
        playerDir = playerPos - transform.position; // EZT NEM ÉRTEM

        angle = Vector3.SignedAngle(playerDir, transform.forward, Vector3.up);

        lastIndex = GetIndex(angle);
        spriteRenderer.sprite = sprites[lastIndex];




      


    }
    

    private int GetIndex(float angle)
    {
        // front 
        if(angle > -22.5f && angle < 22.5f)
        {
            return 0;
        }
        if ( angle >= 22.5f && angle < 67.5f)
        {
            return 7;
        }
        if (angle >= 67.5f && angle < 112.5f )
        {
            return 6;
        }
        if ( angle >= 112.5f && angle < 157.5f )
        {
            return 5;
        }


        // back
        if(angle <= -157.5f || angle >= 157.5f)
        {
            return 4;
        }
        if ( angle > -157.5f && angle < -112.5f)
        {
            return 3;
        }
        if ( angle >= -112.5f && angle < -67.5f)
        {
            return 2;
        
        }
        if (angle >= -67.5f && angle < -22.5f)
        {
            return 1;
        }



        return lastIndex;
    }


    private void OnDrawGizmos()
    {
/*
        Gizmos.color = Color.red;
        Gizmos.DrawLine(player.position,transform.position);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position +transform.forward * 2);
*/

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position - new Vector3(0,0,-10), transform.position + new Vector3(0,0,10));
        Gizmos.DrawLine(transform.position - new Vector3(-10, 0, 0), transform.position + new Vector3(10, 0, 0));
    }
}
