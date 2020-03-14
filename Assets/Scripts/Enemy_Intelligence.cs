using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Intelligence : MonoBehaviour
{
    // Start is called before the first frame update

    NavMeshAgent Enemy;
    Animator Weapon;
    public Transform Sl,Sl2,Sf,Sr,Sr2, Obbiective;
    public bool Find = false,elab=false,elab2 = false;
    public int n,i=0;
    public GameObject Arm;
  //bool attack = false;
    public Transform[] Position = new Transform[10];
    
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Ti ha colpito:" + collision.gameObject.name);
        if (collision.gameObject.tag == "Weapon")
        {
            
            Destroy(gameObject);

        }
        if(collision.gameObject.tag=="Takable" && gameObject.tag == "Weapon")
        {
            Find = !Find
;        }
    }


    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        Weapon = Arm.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit Obl, Obf, Obr;
        if (Physics.Raycast(Sl.position,Sl.forward * 15, out Obl) && !Find)
        {
            //Debug.Log("L colpisce :" + Obl.collider.gameObject.name);
            Debug.DrawRay(Sl.position, Sl.forward * 15, Color.green);
            if (Obl.collider.gameObject.tag == "Takable")
            {
                
                Obbiective = Obl.collider.transform;
                Find = true;
            }
        }
        if (Physics.Raycast(Sl2.position, Sl2.forward * 15, out Obl) && !Find)
        {
            //Debug.Log("L colpisce :" + Obl.collider.gameObject.name);
            Debug.DrawRay(Sl2.position, Sl2.forward * 15, Color.green);
            if (Obl.collider.gameObject.tag == "Takable")
            {

                Obbiective = Obl.collider.transform;
                Find = true;
            }
        }
        if (Physics.Raycast(Sr.position, Sr.forward * 15, out Obr) && !Find)
        {
            //Debug.Log("R colpisce :" + Obl.collider.gameObject.name);
            Debug.DrawRay(Sr.position, Sr.forward * 15, Color.green);
            if (Obr.collider.gameObject.tag == "Takable")
            {
                
                Obbiective = Obr.collider.transform;
                Find = true;
            }
        }
        if (Physics.Raycast(Sr2.position, Sr2.forward * 15, out Obr) && !Find)
        {
            //Debug.Log("R colpisce :" + Obl.collider.gameObject.name);
            Debug.DrawRay(Sr2.position, Sr2.forward * 15, Color.green);
            if (Obr.collider.gameObject.tag == "Takable")
            {

                Obbiective = Obr.collider.transform;
                Find = true;
            }
        }
        if (Physics.Raycast(Sf.position, Sf.forward * 15, out Obf))
        {
            //Debug.Log("F colpisce :" + Obl.collider.gameObject.name);
            Debug.DrawRay(Sf.position, Sf.forward * 15, Color.green);
            if (Obf.collider.gameObject.tag == "Takable" && !Find)
            {
                
                Obbiective = Obf.collider.transform;
                Find = true;
            }
            else if (Find && !elab)
            {
                if (Obf.collider.gameObject.tag != "Takable")
                {
                    StartCoroutine(WaitToFind(Obf,Obl,Obr));
                }
            }
        }

        if (Find && Obbiective != null)
        {
            i = 0;
            transform.LookAt(Obbiective);
            Enemy.SetDestination(Obbiective.position);
            /*if (Enemy.remainingDistance < 3 && !attack)
            {
                attack = true;
                string temp = gameObject.tag;
                gameObject.tag = "Weapon";
                Weapon.SetBool("Attack", attack);
                StartCoroutine(WaitAttack(temp));
            }*/
        }

        else if (Find && Obbiective == null)
            Find = false;

        else if (!Find)
        {
            Enemy.SetDestination(Position[i].position);
            if (Enemy.remainingDistance < 2f)
            {
                i = Random.Range(0, 7);
            }

        }
        



    }

    /*IEnumerator WaitAttack(string temp)
    {
        if(!elab2)
        {
            elab2 = true;
            yield return new WaitForSeconds(0.3f);
            if(temp == "Takable")
                gameObject.tag = "Takable";
            else if(temp == "Enemy")
                gameObject.tag = "Takable";
            attack = false;
            Weapon.SetBool("Attack", attack);
            elab2 = false;
        }

    }*/

    IEnumerator WaitToFind(RaycastHit Obf, RaycastHit Obl, RaycastHit Obr)
    {
        
        if(!elab)
        {
            elab = true;
            n = 0;
            while (n<500 && Obbiective != null)
            {
                
                yield return new WaitForSeconds(0.01f);
                if (Physics.Raycast(Sf.position, Sf.forward * 15, out Obf))
                {
                    Debug.DrawRay(Sf.position, Sf.forward * 15, Color.green);
                    if (Obf.collider.gameObject.tag == "Takable")
                    {
                        break;
                    }
                    
                }
                if (Physics.Raycast(Sl.position, Sl.forward * 15, out Obl))
                {
                    Debug.DrawRay(Sl.position, Sl.forward * 15, Color.green);
                    if (Obf.collider.gameObject.tag == "Takable")
                    {
                        break;
                    }
                    
                }
                if (Physics.Raycast(Sl2.position, Sl2.forward * 15, out Obl))
                {
                    Debug.DrawRay(Sl2.position, Sl2.forward * 15, Color.green);
                    if (Obf.collider.gameObject.tag == "Takable")
                    {
                        break;
                    }
                    
                }
                if (Physics.Raycast(Sr.position, Sr.forward * 15, out Obr))
                {
                    Debug.DrawRay(Sr.position, Sr.forward * 15, Color.green);
                    if (Obf.collider.gameObject.tag == "Takable")
                    {
                        break;
                    }
                    
                }
                if (Physics.Raycast(Sr2.position, Sr2.forward * 15, out Obr))
                {
                    Debug.DrawRay(Sr2.position, Sr2.forward * 15, Color.green);
                    if (Obf.collider.gameObject.tag == "Takable")
                    {
                        break;
                    }
                    
                }

                
                if (Find == true && n == 499 || Obbiective == null)
                {
                    Find = false;
                    Obbiective = null;
                }
                    
                n++;
            }

            elab = false;
        }
    }
}
