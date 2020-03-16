using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class RandomList : MonoBehaviour
{
    // Start is called before the first frame update

    Item[] items = new Item[4];
    int[] counts = new int[4];
    public TextMeshProUGUI[] ListItems = new TextMeshProUGUI[4];
    int maxCount = 3;
    int[] currcounts = new int[4];
    public CartInventory inventory;

    void Start()
    {
        
        for (int i=0;i<ListItems.Length;i++)
        {
            items[i] = ItemList.instance.itemPrefabs[Random.Range(0, ItemList.instance.itemPrefabs.Count)].GetComponent<Item>();
            counts[i] = Random.Range(1, maxCount);
            currcounts[i] = 0;
            //ListItems[i].text = items[i].itemName + ": "+currcounts[i]+"/" + counts[i];
            //Rewrite();
        }
        Rewrite();

    }

    void Rewrite()
    {
        for (int i = 0; i < ListItems.Length; i++)
        {
            ListItems[i].text = items[i].itemName + ": " + currcounts[i] + "/" + counts[i];
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        bool rewrite = false;
        for (int i=0;i<ListItems.Length;i++)
        {
            int last = currcounts[i];
            int currCount = inventory.items.Where(x => x.itemName == items[i].itemName).Count();
            currcounts[i] = currCount;
            if (last!=currcounts[i])
            {
                rewrite = true;
            }
        }
        if (rewrite)
            Rewrite();
    }
    public bool EvaluateFinished()
    {
        bool finished = true;
        for (int i = 0; i < ListItems.Length; i++)
        {
            if (currcounts[i] < counts[i])
                finished = false;
        }
        return finished;
    }
}
