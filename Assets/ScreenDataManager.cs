
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScreenDataManager : MonoBehaviour
{

    public TextMeshProUGUI health;   
    public TextMeshProUGUI armor;
    public TextMeshProUGUI pistolAmmunation;
    public TextMeshProUGUI shotgunAmmunation;
    public TextMeshProUGUI bazookaAmmunation;

    //
    public Image PistolAvailability;
    public Sprite weGotPistol;

    public Image ShotgunAvailability;
    public Sprite weGotShotgun;
    
    public Image BazookaAvailability;
    public Sprite weGotBazooka;

    //
    public Image okayStatus;
    public Sprite okay;
    public Sprite unwell;
    public Sprite ouch;
    public Sprite dead;


    public GameObject yellowKey;
    public GameObject blueKey;
    public GameObject redKey;

    // fegvyer rendelkezésre állás

    private static ScreenDataManager instance;
    public static ScreenDataManager instanceHandler
    {    
            get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);

        }
        else { instance = this; }

    }


    public void HealthReport(int healthChanged)
    {
        health.text = healthChanged.ToString() + " %";
        OkayIndicator(healthChanged);  
    }

public  void ArmorReport(int armorChanged)
    {
        armor.text = armorChanged.ToString() + "%";

    }


    public void PistolPickUp( bool weGetPistol)
    {
        if (weGetPistol)
        {            PistolAvailability.sprite = weGotPistol;        }
        
    }

    public void ShotgunPickUp(bool weGetShotgun)
    {
        if (weGetShotgun)
        { ShotgunAvailability.sprite = weGotShotgun; }


    }
    public void BazookaPickUp(bool weGetBazooka)
    {
        if (weGetBazooka)
        { BazookaAvailability.sprite = weGotBazooka; }


    }

    public  void AmmunationReport(int ammunationChanged)
    {
        pistolAmmunation.text = ammunationChanged.ToString();


    }
    
    public void ShotgunAmmunationReport(int ammunationChanged) 
    {
        shotgunAmmunation.text = ammunationChanged.ToString();


    }

    public void BazookaAmmunationReport(int ammunationChanged)  // todo
    {
        bazookaAmmunation.text = ammunationChanged.ToString();


    }
    

    public  void OkayIndicator(int healthStuff)
    {

        if (healthStuff > 60 )
        {
            okayStatus.sprite = okay;
        }
        if (healthStuff <= 60 && healthStuff > 20)
        { 
            okayStatus.sprite = unwell;       
        }
        if (healthStuff <= 20 && healthStuff > 0)
        {
            okayStatus.sprite = ouch;
        }
        if (healthStuff <= 0)
        {
            okayStatus.sprite = dead; 
        }



    
    }

    public void KeysReport(string keyColor)
    {
        if (keyColor == "red")
        {
            redKey.SetActive(true);
        }
        if (keyColor == "blue")
        {
            redKey.SetActive(true);
        }
        if (keyColor == "yellow")
        {
            redKey.SetActive(true);
        }



    }



   public void ClearKeys()
    {      
            redKey.SetActive(false);      
            redKey.SetActive(false);      
            redKey.SetActive(false);
    }

}
