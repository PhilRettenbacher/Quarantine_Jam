using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfItemSpawner : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public float itemsPerUnit = 0.5f;
    public bool randomize;
    public float rotation;

    [Range(0, 1)]
    public float probability = 0.1f;

    //only used when randomize is set to false;
    public int itemId;

    // Start is called before the first frame update
    void Start()
    {
        SpawnItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnItem()
    {
        float distance = Vector3.Distance(StartPoint.position, EndPoint.position);
        int count = Mathf.RoundToInt(distance * itemsPerUnit)+1;
        for(int i = 0; i<count; i++)
        {
            if (Random.Range(0, 1f) > probability)
                continue;
            float t = i / (itemsPerUnit*distance);
            Vector3 position = Vector3.Lerp(StartPoint.position, EndPoint.position, t);
            int id = itemId;
            if(randomize)
            {
                id = Random.Range(0, ItemList.instance.itemPrefabs.Count);
            }
            Instantiate(ItemList.instance.itemPrefabs[id], position, transform.rotation*Quaternion.Euler(0, rotation, 0), transform);
        }
    }
}
