using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float Max_Rotation_Y, Min_Rotation_Y, Sensivity=2f;
    public Transform Body;
    float Mx, My;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mx += Input.GetAxis("Mouse X");
        My -= Input.GetAxis("Mouse Y");
        //Mx = Mathf.Clamp(Mx,Body.rotation.y -20)
        My = Mathf.Clamp(My, Min_Rotation_Y, Max_Rotation_Y);

        transform.rotation = Quaternion.Euler(My * Sensivity, Body.rotation.y + (Mx * Sensivity) , 0);
        
    }
}
