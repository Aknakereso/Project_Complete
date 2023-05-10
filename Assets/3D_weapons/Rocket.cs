using UnityEngine;

public class Rocket : MonoBehaviour
{


    AudioSource audio;
   [SerializeField]  AudioSource audioChild;

    MeshRenderer mr;
    SphereCollider collider;
    
    [SerializeField] float timer;
    Enemy_Life enemyLife;

    public int damage;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        audioChild = GetComponent<AudioSource>();

        mr = GetComponent<MeshRenderer>();
        collider = GetComponent<SphereCollider>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timer);

        if (Input.GetKeyDown(KeyCode.L))
        {
            mr.enabled = false;
            collider.enabled = false;

            audioChild.Play();
        }


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

            audioChild.Play();
            


            Destroy(gameObject,1);





        }
        else { return; }

        //  a célpontot lökje arrébb a robbanása


    }



}
