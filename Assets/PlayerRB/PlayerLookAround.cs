using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{
    [SerializeField] Transform player;

    public float mouseSensy;

    float rotationOnX;


   
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;


    }

    // Update is called once per frame
    void Update()
    {

        float sideWays = Input.GetAxis("Mouse X") * mouseSensy * Time.deltaTime;
        float tilting = Input.GetAxis("Mouse Y") * mouseSensy * Time.deltaTime;

        player.Rotate(Vector3.up * sideWays);

        rotationOnX -= tilting;
        rotationOnX = Mathf.Clamp(rotationOnX, -90, 90);

        transform.localRotation = Quaternion.Euler(rotationOnX, 0f, 0f);

    }
}
