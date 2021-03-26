using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveDistance = 200;
    public float moveSpeed = 10;

    public EnemyType myType;
    public int health;

    public Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        SetUp();
        StartCoroutine(Move());
        
    }

    void SetUp()
    {
        switch(myType)
        {
            case EnemyType.Ranged:
                health = 50;
                break;
            case EnemyType.Light:
                health = 100;
                break;
            case EnemyType.Heavy:
                health = 200;
                break;
        }
    }

    void Update()
    {
       /*if(Input.GetKeyDown(KeyCode.Space))
       {
            
       }*/

        if (Input.GetKeyDown("k"))
            Die();

        
        /*
         if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("ChangeAnimation");
            //anim.SetBool("useSpin", !anim.GetBool("useSpin"));
        }
        // */
    }

    IEnumerator Move()
    {
        if(anim)
            anim.SetFloat("Speed", moveSpeed);
        for (int i = 0; i < moveDistance; i++)
        {
            //float x = Input.GetAxis("Horizontal");
            //float z = Input.GetAxis("Vertical");
            //transform.Translate(Vector3 move = transform.right * x + transform.forward * z * moveSpeed* Time.deltaTime
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            yield return null;
            
        }
        //change 180 to random number between 0 - 360
        transform.Rotate(Vector3.up * 180);

        if(anim)
        anim.SetFloat("Speed", 0);
        yield return new WaitForSeconds(3);

        StartCoroutine(Move());
        
    }

    public enum EnemyType
        {
            Light,
            Heavy,
            Ranged
        }

    /*void Die()
    {
        //GameManage.instance.enemiesKilled++;
        GameManage.instance.AddScore(50);
        //EnemyManager.instance.OnEnemyKilled(this.gameObject);
        this.gameObject.SetActive(false);
    }*/

    void TakeDamage(int _damage)
    {
        anim.SetTrigger("Hit");
        health -= _damage;
        GameManage.instance.AddScore(10);
        if (health <= 0)
            Die();
    }

    void Die()
    {
        anim.SetTrigger("Die");
        GameManage.instance.AddScore(100);
        //EnemyManager.instance.EnemyKilled(gameObject);
        StopAllCoroutines();
        Destroy(this.gameObject);
    }


}
