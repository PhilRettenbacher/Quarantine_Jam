using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public CartInventory inventory;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Takable")
        {
            var item = other.gameObject.GetComponent<Item>();
            if(item)
            {
                inventory.AddItem(item);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Takable")
        {
            var item = other.gameObject.GetComponent<Item>();
            if (item)
            {
                inventory.RemoveItem(item);
            }
        }
    }
}
