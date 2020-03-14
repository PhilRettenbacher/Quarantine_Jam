using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPickup : MonoBehaviour
{
    public CartInventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Collectible")
        {
            inventory.Add(1/*,other.gameObject*/);
            Destroy(other.transform.root.gameObject);
        }
    }
}
