using UnityEngine;

public class Fog : MonoBehaviour
{
    public Akna aknaScript;

 
    public UI_arms first;
   public UIarms_II second;

    bool primary;
    bool secondary;

   

    void Update()
    {
        primary = first.youCanClick;
        secondary = second.youCanClickII;


        if (Input.GetMouseButtonDown(0))
        {
            

            Ray myRay = new Ray(transform.position, transform.forward);
            bool hit = Physics.Raycast(myRay, out RaycastHit rayInfo);

            aknaScript = rayInfo.collider.GetComponent<Akna>();



            if (aknaScript != null && primary)
            {
               
            

                Debug.Log("van célpont");
                aknaScript.GetBabbed(10);
                


            }
            else if (aknaScript != null && secondary)
            {

             

                Debug.Log("van célpont 2");
                aknaScript.GetBabbed(200);
                


            }
            else { return; }

            
        }



        
    }

    private void OnDrawGizmos()
    {
       Gizmos.color = Color.red;
       Gizmos.DrawLine(transform.position, transform.position + transform.forward * 10);
        
    }
   

}
