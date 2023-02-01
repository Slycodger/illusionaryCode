using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLineAndTimer : MonoBehaviour
{       
    [Header("Outside variables")]
    [Tooltip("The folder with all gameObjects excluding finish area in it")]
    public GameObject Everything;
    [Tooltip("The folder with the finish area in it")]
    public GameObject FinishArea;
    [Tooltip("The text showing the in-game time taken")]
    public TextMeshProUGUI text;
    [Tooltip("The text showing time taken at finish area")]
    public TextMeshProUGUI BigText;
    [Space(15)]
    [Header("Non-changeable variables")]
    [Tooltip("Time in secounds taken to complete game")]
    public float TimeTaken;
    private Collider2D colliders;
    private bool Toggle;
    private int secounds;
    private int minutes;
    private int hours;
    // Update is called once per frame
    void Update()
    {
        //Create OverLapBox and put all collisions in a array
        colliders = Physics2D.OverlapBox(transform.position, transform.localScale, 0);
        //Check array for if player is in
        if (colliders)
        {
            if (colliders.gameObject.CompareTag("Player"))
            {
                colliders.gameObject.transform.position = new Vector2(0, 0);
                Toggle = true;
            }
        }
        //Check if toggle is true or false and do something based on that
        if(Toggle == false)
        {
            TimeTaken += Time.deltaTime;
        }
        //Make text box display time taken
        hours = Mathf.FloorToInt(TimeTaken / 3600);
        minutes = Mathf.FloorToInt(TimeTaken - hours * 3600)/60;
        secounds = Mathf.FloorToInt(TimeTaken - (hours * 3600)  - (minutes * 60));

        string time = string.Format("{0:00} : {1:00} : {2:00}", hours, minutes, secounds);
        text.text = time;
        BigText.text = time;
        if (Toggle == true)
        {
            Everything.SetActive(false);
            FinishArea.SetActive(true);
        }
    }
}
