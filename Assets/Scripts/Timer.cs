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
    Checkout checkout;
    // Start is called before the first frame update
    void Start()
    {
        //Test
        //StartTimer();
        countDownText.gameObject.SetActive(false);
        checkout = gameObject.GetComponent<Checkout>();
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
                countDownText.gameObject.SetActive(false);
                checkout.ShowGameOver();
            }
            countDownText.text = ((int)currTime).ToString();
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
        currTime = maxTime;
        countDownText.gameObject.SetActive(true);
    }
    public void EndTimer()
    {
        timerStarted = false;
        //Checkout -> Receipt
        countDownText.gameObject.SetActive(false);

    }
}
