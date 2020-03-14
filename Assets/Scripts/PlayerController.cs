using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public GameObject Character;
    public float Max_Stamina, Stamina;
    Animator Player;
    public Transform Body;
    bool run = false, Shift = false,elab = false,done=false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Stamina = Max_Stamina;
        rb = gameObject.GetComponent<Rigidbody>();
        Player = Character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Stamina >0)
        {
            Stamina -= 5 * Time.deltaTime;
            Shift = true;
            Player.speed = 2;
            speed = 40;
        }
        else if(!Input.GetKey(KeyCode.LeftShift) && Shift)
        {
            StartCoroutine(Stamina_Wait());
            Shift = false;
            Player.speed = 1;
            speed = 20;
        }

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


    IEnumerator Stamina_Wait()
    {
        if(!elab)
        {
            elab = true;
            float i = 0;
            while (!Input.GetKey(KeyCode.LeftShift))
            {
                yield return new WaitForSeconds(0.1f);
                i += 0.1f;
                if(i == 5)
                {
                    done = true;
                    break;

                }
            }
            if (done)
            {
                StartCoroutine(Stamina_Reload());
            }
            else
                elab = false;
        }
        
    }

    IEnumerator Stamina_Reload()
    {
        while(!Input.GetKey(KeyCode.LeftShift))
        {
            yield return new WaitForSeconds(0.1f);
            Stamina += (Max_Stamina * 0.1f);
            if (Stamina >= Max_Stamina)
                break;
        }
        Stamina = Max_Stamina;
        elab = false;
    }
}
