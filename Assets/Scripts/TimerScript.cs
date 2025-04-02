using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    
    public float time = 100f;
    public float oxygenLevel = 100;
    float fuelLevel;
    public bool EqStatus;

    GameObject timer;
    GameObject oxygen;
    GameObject fuel;
    GameObject status;
    GameObject camHolder;
    public GameObject florbus;
    Player player;

    // Start is called before the first frame update

    void Awake()
    {
        
        florbus = GameObject.Find("Florbus");
        player = florbus.GetComponent<Player>();
    }


    void Start()
    {
        timer = GameObject.Find("Time");
        oxygen = GameObject.Find("O2");
        fuel = GameObject.Find("Fuel");
        status = GameObject.Find("Status");

        InvokeRepeating("Earthquake", 10.0f, 30.0f);
        InvokeRepeating("EarthquakeStop", 15.0f, 30.0f);

        camHolder = GameObject.Find("Camera Holder");

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        TMPro.TextMeshProUGUI ttext = timer.GetComponent<TMPro.TextMeshProUGUI>();

        ttext.text = "Time: " + Mathf.Round(time).ToString();

        TMPro.TextMeshProUGUI otext = oxygen.GetComponent<TMPro.TextMeshProUGUI>();

        otext.text = "Oxygen: " + Mathf.Round(oxygenLevel).ToString() + "%";

        TMPro.TextMeshProUGUI ftext = fuel.GetComponent<TMPro.TextMeshProUGUI>();

        fuelLevel = Mathf.Round(player.jumpSeconds * 10f);

        ftext.text = "Fuel: " + fuelLevel.ToString() + "%";

        TMPro.TextMeshProUGUI etext = status.GetComponent<TMPro.TextMeshProUGUI>();
        


        if (EqStatus == true)
        {
            etext.text = "Planet Status: Danger";
        }

        if(EqStatus == false)
        {
            etext.text = "Planet Status: Normal";
        }



        if (oxygenLevel <= 0)
        {
            /*oxygenLevel = 100;

            time = 100f;
            
            player.jumpSeconds = 10f;*/
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (time == 0)
        {
            //winnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
        }

    }

    void Earthquake()
    {
        EqStatus = true;
        camHolder.GetComponent<CameraShake>().Shake(5f);
    }

    void EarthquakeStop()
    {
        EqStatus = false;
    }
    
}


