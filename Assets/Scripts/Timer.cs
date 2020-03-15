using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool timerStarted;
    public float maxTime;
    float currTime;
    public TextMeshProUGUI countDownText;
    // Start is called before the first frame update
    void Start()
    {
        //Test
        //StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerStarted)
        {
            currTime -= Time.deltaTime;
            if(currTime<=0)
            {
                //End game -> loose
                timerStarted = false;
                currTime = 0;
            }
            countDownText.text = ((int)currTime).ToString();
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
        currTime = maxTime;
    }
    public void EndTimer()
    {
        timerStarted = false;
        //Checkout -> Receipt
    }
}
