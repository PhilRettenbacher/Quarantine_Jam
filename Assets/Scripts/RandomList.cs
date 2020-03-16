using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomList : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] HaveToTake = new GameObject[4];
    Item[] ObjectName = new Item[4];
    string[] Name = new string[4];
    public TextMeshProUGUI[] Ob = new TextMeshProUGUI[4];
    int i;


    void Start()
    {
        
        for (i=0;i<HaveToTake.Length;i++)
        {
            ObjectName[i] = HaveToTake[i].GetComponent<Item>();
            Name[i] = ObjectName[i].ReturnName(); 
        }
        
        Ob[0].text = Name[Random.Range(0, 3)];
        Ob[1].text = Name[Random.Range(0, 3)];
        Ob[2].text = Name[Random.Range(0, 3)];
        Ob[3].text = Name[Random.Range(0, 3)];


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
