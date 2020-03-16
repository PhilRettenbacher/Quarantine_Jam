using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Intelligence : MonoBehaviour
{
    // Start is called before the first frame update

    NavMeshAgent Enemy;
    Animator Weapon;
    int i;
    public bool Find = false,elab=false,elab2 = false;
  //bool attack = false;
    public Transform[] Position = new Transform[10];
    
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Ti ha colpito:" + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {

            Rigidbody p = collision.gameObject.GetComponent<Rigidbody>();
            p.AddForce(collision.transform.position * 200, ForceMode.Impulse);

        }
    }


    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
 
    }

    // Update is called once per frame
    void Update()
    {

        
        if (!Find)
        {
            transform.LookAt(Position[i].position);
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 180, transform.rotation.z);
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

    
}
