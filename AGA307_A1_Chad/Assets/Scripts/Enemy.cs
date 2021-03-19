using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float moveDistance = 500;

    public EnemyType myType;
    public int health;


    void Start()
    {
        //SetStartHealth()
        if (myType == EnemyType.Ranged)
            health = 50;
        if (myType == EnemyType.Light)
            health = 100;
        if (myType == EnemyType.Heavy)
            health = 200;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Move());
        }

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

        transform.Rotate(Vector3.up * 180);

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
