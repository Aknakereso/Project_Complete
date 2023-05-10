
using UnityEngine;

public class FaceToPlayer : MonoBehaviour
{ // Doom anim Enemy hez

    public Transform player;
   

    void Start()
    {
        //player = FindObjectOfType<Placeholder>().transform;


    }

    
    void Update()
    {
          
            Vector3 newLookAt = player.position;   // ez a fontos
            newLookAt.y = transform.position.y;

            transform.LookAt(newLookAt);
        
    }
}
