using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class CartInventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int score { get; private set; }

    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item item)
    {
        if(!items.Contains(item))
        {
            items.Add(item);
            Debug.Log("Added " + item.itemName + " to cart!");
            RecalculateScore();
        }
    }
    public void RemoveItem(Item item)
    {
        if(items.Contains(item))
        {
            items.Remove(item);
            Debug.Log("Removed " + item.itemName + " from cart!");
            RecalculateScore();
        }
    }
    void RecalculateScore()
    {
        score = items.Sum(x => x.score);
        scoreText.text = "Points: " + score;
    }
}
