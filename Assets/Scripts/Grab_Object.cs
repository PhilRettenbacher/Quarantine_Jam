using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Object : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform Point;
    bool take = false;

    //Public for test
    public GameObject Temp;
    Rigidbody Tobj;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !take)
        {
            Debug.DrawRay(transform.position, transform.forward * 100, Color.blue);
            RaycastHit Object;
            if (Physics.Raycast(transform.position, transform.forward, out Object, 20f))
            {
                if(Object.collider.gameObject.tag != "Player")
                {
                    
                    if (Object.collider.gameObject.tag == "Takable")
                    {
                        take = true;
                        Debug.DrawRay(transform.position, transform.forward * 20, Color.red);
                        Temp = Object.collider.gameObject;
                        Tobj = Temp.GetComponent<Rigidbody>();
                        if(Tobj)
                        {
                            Tobj.useGravity = false;
                            Temp.transform.parent = Point;
                            Temp.transform.position = Point.position;
                        }
                        
                    }
                }
                
                
            }
        }
        else if (Input.GetMouseButtonUp(1) && take)
        {
            take = false;
            Rigidbody Tobj = Temp.GetComponent<Rigidbody>();
            if (Temp && Tobj)
            {
                Temp.transform.parent = null;
                Tobj.useGravity = true;
            }
            Temp = null;
            Tobj = null;
        }
        if(take)
        {
            Temp.transform.position = Point.position;
        }
    }
}
