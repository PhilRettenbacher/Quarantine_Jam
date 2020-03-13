using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public GameObject Character;
    Animator Player;
    public Transform Body;
    bool run = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Player = Character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetAxis("Vertical") != 0)
        {
            run = true;
            Player.SetBool("Run", run);
        }
        else
        {
            run = false;
            Player.SetBool("Run", run);
        }
        rb.velocity = (Body.forward * speed * Input.GetAxis("Vertical"));
        Body.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0);
    }
}
