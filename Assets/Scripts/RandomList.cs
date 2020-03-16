using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomList : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] HaveToTake = new GameObject[5];
    Item[] ObjectName = new Item[5];
    string[] Name = new string[5];
    int i;


    void Start()
    {
        
        for (i=0;i<HaveToTake.Length;i++)
        {
            ObjectName[i] = HaveToTake[i].GetComponent<Item>();
            Name[i] = ObjectName[i].ReturnName(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
