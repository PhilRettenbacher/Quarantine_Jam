using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toiilet_Paper_Shooter : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PlayerView;
    CartInventory inventory;
    //public Transform Hand;
    public GameObject Bullet;
    public float distance;
    void Start()
    {
        inventory = gameObject.GetComponent<CartInventory>();
    }



    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(PlayerView.transform.position, PlayerView.transform.forward * distance, Color.green);

        if (Input.GetMouseButtonDown(0) && inventory.count >0)
        {
            inventory.Remove(1);
            GameObject B = Instantiate(Bullet, PlayerView.transform.position, Quaternion.identity);
            Rigidbody bullet = B.GetComponent<Rigidbody>();
            bullet.tag = "Collectible";
            bullet.AddForce(PlayerView.transform.forward * 1200);
          //Destroy(B, 5f);

        }
    }
}
