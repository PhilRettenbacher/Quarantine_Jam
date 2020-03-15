using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public List<GameObject> itemPrefabs = new List<GameObject>();
    public static ItemList instance;
    void Awake()
    {
        instance = this;
    }
    
}
