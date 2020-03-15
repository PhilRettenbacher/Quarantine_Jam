using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Timer timer;
    public Checkout checkout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(timer.timerStarted);
            if (!timer.timerStarted)
                timer.StartTimer();
            else
            {
                timer.EndTimer();
                checkout.GenerateReceipt();
            }
            //inventory = other.transform.root.gameObject.GetComponent<CartInventory>();
            //GenerateReceipt();
        }
    }
}
