using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toiilet_Paper_Shooter : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PlayerView;
    //public Transform Hand;
    public GameObject Bullet;
    public float ammo;
    public float distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(PlayerView.transform.position, PlayerView.transform.forward * distance, Color.green);

        if (Input.GetMouseButtonDown(0) && ammo >0)
        {
            ammo--;
            GameObject B = Instantiate(Bullet, PlayerView.transform.position, Quaternion.identity);
            Rigidbody bullet = B.GetComponent<Rigidbody>();
            bullet.AddForce(PlayerView.transform.forward * 1200);
            Destroy(B, 5f);

        }



        
    }
}
