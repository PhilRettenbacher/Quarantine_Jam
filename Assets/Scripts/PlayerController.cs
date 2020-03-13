using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float acceleration;
    public float rotationSpeed;
    public float maxSpeed;
    public float sideForce;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputY = Input.GetAxis("Vertical");

        float currAccel = (maxSpeed - rb.velocity.magnitude) / maxSpeed;

        float dot = Vector3.Dot(transform.right, rb.velocity.normalized);

        rb.velocity += (transform.forward * acceleration * Time.deltaTime * currAccel * inputY - transform.right*Time.deltaTime*sideForce*dot*rb.velocity.magnitude);
        rb.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0);
    }
}
