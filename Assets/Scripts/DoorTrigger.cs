using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Timer timer;
    public Checkout checkout;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("DoorOpen", true);
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
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("DoorOpen", false);
        }
    }
}
