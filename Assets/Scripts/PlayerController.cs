using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public Canvas HUD, PAUSE,List;
    public GameObject Character;
    public float Max_Stamina, Stamina;
    bool pause = false,list = false;
    Animator Player;
    public Transform Body;

    bool run = false, Shift = false,elab = false,done=false;

    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {

        HUD.gameObject.SetActive(true);
        PAUSE.gameObject.SetActive(false);
        List.gameObject.SetActive(false);
        Stamina = Max_Stamina;
        rb = gameObject.GetComponent<Rigidbody>();
        Player = Character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            pause = true;
            HUD.gameObject.SetActive(false);
            PAUSE.gameObject.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
            
        }
        if(!PAUSE.gameObject.active && pause)
        {
            pause = false;
        }
            

        if (Input.GetKeyDown(KeyCode.Tab) && !list && !pause)
        {
            list = true;
            List.gameObject.SetActive(true);
            HUD.gameObject.SetActive(true);
            PAUSE.gameObject.SetActive(false);
            Cursor.visible = true;
            Time.timeScale = 1;

        }
        else if (Input.GetKeyDown(KeyCode.Tab) && list && !pause)
        {
            list = false;
            List.gameObject.SetActive(false);
            HUD.gameObject.SetActive(true);
            PAUSE.gameObject.SetActive(false);
            Cursor.visible = false;
            

        }


        if (Input.GetKey(KeyCode.LeftShift) && Stamina >0)
        {
            Stamina -= 20 * Time.deltaTime;
            Shift = true;
            Player.speed = 2;
            speed = 80;
        }
        else if(!Input.GetKey(KeyCode.LeftShift) && Shift)
        {
            Shift = false;
            StartCoroutine(Stamina_Wait());
            Player.speed = 1;
            speed = 40;
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
        rb.rotation *= Quaternion.Euler(0, rotationSpeed * Time.fixedDeltaTime * Input.GetAxis("Horizontal"), 0);
    }


    IEnumerator Stamina_Wait()
    {
        if(!elab)
        {
            elab = true;
            float i = 0;
            //Debug.Log("Im going to Wait");
            while (!Shift)
            {
                //Debug.Log("Turn:" + i);
                yield return new WaitForSeconds(0.1f);
                i += 0.1f;

                if(i >= 5)
                {
                    Debug.Log("DONE");
                    done = true;
                    break;

                }
            }
            if (done)
            {
                //Debug.Log("Im going to reload");
                StartCoroutine(Stamina_Reload());
            }
            else
                elab = false;
        }
        
    }

    IEnumerator Stamina_Reload()
    {
        while(!Shift)
        {
            Debug.Log("reload");
            yield return new WaitForSeconds(0.1f);
            Stamina += (Max_Stamina * 0.01f);
            if (Stamina >= Max_Stamina)
                break;
        }
        Stamina = Max_Stamina;
        elab = false;
    }
}
