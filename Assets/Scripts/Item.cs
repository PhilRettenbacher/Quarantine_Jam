using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int score;
    public string itemName;

    public string ReturnName()
    {
        return itemName;
    }
}
