using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Settings : MonoBehaviour
{
    // Start is called before the first frame update
    public float Range,Intensity;
    Light al;
    void Start()
    {
        al = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

        al.range = Range;
        al.intensity = Intensity;
        
    }
}
