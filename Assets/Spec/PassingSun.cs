
using UnityEngine;

public class PassingSun : MonoBehaviour
{

    [SerializeField] float sunPassing;

    
    void Update()
    {
        transform.Rotate(0,sunPassing,0);
    }
}
