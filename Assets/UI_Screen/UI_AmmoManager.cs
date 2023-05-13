using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AmmoManager : MonoBehaviour
{
    [SerializeField] GameObject pistolUI; // UI text elemek
    [SerializeField] GameObject shotgunUI;
    [SerializeField] GameObject bazookaUI;
    [Space]

    [SerializeField] GameObject pistol;  // eszközök, (pistolAnim)
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject bazooka;

    void Start()
    {
        pistol.SetActive(false);
        shotgun.SetActive(false);
        bazooka.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (pistol.activeSelf)
        {
            pistolUI.SetActive(true);
        }
        else {pistolUI.SetActive(false); }

        if (shotgun.activeSelf)
        {
            shotgunUI.SetActive(true);
        }
        else { shotgunUI.SetActive(false); }

        if (bazooka.activeSelf)
        {
            bazookaUI.SetActive(true);
        }
        else { bazookaUI.SetActive(false); }
    }

   
}
