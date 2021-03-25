using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveDistance = 500;

    public EnemyType myType;
    public int health;


    void Start()
    {
        SetUp();
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
       // if(Input.GetKeyDown(KeyCode.Space))
       // {
            StartCoroutine(Move());
        //}

        if (Input.GetKeyDown("k"))
            Die();
    }

    IEnumerator Move()
    {
        for(int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
            
        }

        //transform.Rotate(Vector3.up * 180);

        yield return new WaitForSeconds(3);

        StartCoroutine(Move());
        
    }

    public enum EnemyType
        {
            Light,
            Heavy,
            Ranged
        }

    void Die()
    {
        //GameManage.instance.enemiesKilled++;
        GameManage.instance.AddScore(50);
        //EnemyManager.instance.OnEnemyKilled(this.gameObject);
        this.gameObject.SetActive(false);
    }


}
