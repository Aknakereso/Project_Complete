using UnityEngine;

public class Rocket : MonoBehaviour
{


    AudioSource audio;
 

    MeshRenderer mr;
    SphereCollider collider;
    
    [SerializeField] float timer;
    Enemy_Life enemyLife;

    public int damage;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        mr = GetComponent<MeshRenderer>();
        collider = GetComponent<SphereCollider>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timer);

   
    }

    private void OnCollisionEnter(Collision collision)
    {
        audio.Play();
        enemyLife = collision.collider.GetComponent<Enemy_Life>();

        if ( enemyLife!= null)
        {
            enemyLife.DecreaseHealth(damage);
            mr.enabled = false;
            collider.enabled = false;
 
            Destroy(gameObject,1.5f);

        }
       

    }

  

}
