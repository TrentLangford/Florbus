using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    
    public float time = 100f;
    public int oxygenLevel = 100;
    float fuelLevel;

    GameObject timer;
    GameObject oxygen;
    GameObject fuel;
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
       

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        TMPro.TextMeshProUGUI ttext = timer.GetComponent<TMPro.TextMeshProUGUI>();

        ttext.text = "Time: " + Mathf.Round(time).ToString();

        TMPro.TextMeshProUGUI otext = oxygen.GetComponent<TMPro.TextMeshProUGUI>();

        otext.text = "Oxygen: " + oxygenLevel.ToString() + "%";

        TMPro.TextMeshProUGUI ftext = fuel.GetComponent<TMPro.TextMeshProUGUI>();

        fuelLevel = Mathf.Round(player.jumpSeconds * 10f);

        ftext.text = "Fuel: " + fuelLevel.ToString() + "%";



        if (oxygenLevel == 0)
        {
            oxygenLevel = 100;

            time = 100f;
            
            player.jumpSeconds = 10f;
        }

        if (time == 0)
        {
            //winnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
        }

    }
    
}


