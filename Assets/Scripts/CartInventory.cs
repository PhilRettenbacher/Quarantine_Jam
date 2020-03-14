using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CartInventory : MonoBehaviour
{
    public GameObject tpPrefab;
    List<GameObject> currentInventory = new List<GameObject>();
    public Transform container;
    public Vector3 scaling;
    public TextMeshProUGUI pointText;

    public int count { get => currentInventory.Count; }

    //the gridsize in which the toilet paper should be stacked
    public int maxWidth;
    public int maxLength;

    // Start is called before the first frame update
    void Start()
    {
        //Test
        //Add(50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Add(int count)
    {
        int currCount = currentInventory.Count;
        for(int i = 0; i<count; i++)
        {
            int idx = i + currCount;
            currentInventory.Add(Instantiate(tpPrefab, container));
            int widthPos = idx % maxWidth;
            int lengthPos = Mathf.FloorToInt(idx / maxWidth) % maxLength;
            int height = Mathf.FloorToInt(idx / (maxWidth * maxLength));

            currentInventory[idx].transform.localPosition = new Vector3((widthPos-(maxWidth-1)/2f)*scaling.x, height*scaling.y, lengthPos*scaling.z);

        }
        pointText.text = "Points: " + this.count;
    }
    public void Remove(int count)
    {
        for(int i = 0; i<count; i++)
        {
            int idx = this.count - i - 1;
            Destroy(currentInventory[idx]);
            currentInventory.RemoveAt(idx);
        }
        pointText.text = "Points: " + this.count;
    }
}
