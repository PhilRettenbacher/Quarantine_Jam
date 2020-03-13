using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    public Transform Body;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=(Body.forward * speed * Input.GetAxis("Vertical"));
        Body.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0);
    }
}
