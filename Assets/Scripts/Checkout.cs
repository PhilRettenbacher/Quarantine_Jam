using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Checkout : MonoBehaviour
{
    CartInventory inventory;
    public GameObject receiptUI;
    public void GenerateReceipt()
    {
        var receipt = Instantiate(receiptUI);
        ReceiptHandler handler = receipt.GetComponent<ReceiptHandler>();
        for(int i = 0; i<ItemList.instance.itemPrefabs.Count;i++)
        {
            Item currItem = ItemList.instance.itemPrefabs[i].GetComponent<Item>();
            Time.timeScale = 0;
            int count = inventory.items.Where(x => x.itemName == currItem.itemName).Count();

            Debug.Log(currItem.itemName + " : " + count);
            if (count > 0)
            {
                int price = currItem.score * count;
                var pos = Instantiate(handler.entryPrefab, handler.listObj.transform);
                ReceiptEntry entry = pos.GetComponent<ReceiptEntry>();
                entry.itemName.text = count.ToString() + "x " + currItem.itemName;
                entry.itemAmount.text = price.ToString() + ",-";
            }

        }
        var pos1 = Instantiate(handler.entryPrefab, handler.listObj.transform);
        ReceiptEntry entry1 = pos1.GetComponent<ReceiptEntry>();
        entry1.itemName.text = "Total:";
        entry1.itemName.fontStyle = TMPro.FontStyles.Bold;
        entry1.itemAmount.text = inventory.score + ",-";
        entry1.itemAmount.fontStyle = TMPro.FontStyles.Bold;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.tag=="Player")
        {
            inventory = other.transform.root.gameObject.GetComponent<CartInventory>();
            GenerateReceipt();
        }
    }
}
