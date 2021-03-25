using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints = new Transform[8];
    public GameObject[] enemyTypes = new GameObject[6];

    public static EnemyManager instance;

    public List<GameObject> enemies;

    public EnemySize size;
    float scaleFactor = 1;


    void Start()
    {
       /*for(int i = 0; i < 101; i++)
       {
            print(i);
       }*/
        SpawnEnemy();

        SetUp();
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int rndEnemy = Random.Range(0, enemyTypes.Length);
            //Instantiate(enemyTypes[rndEnemy], spawnPoints[i].position, spawnPoints[i].rotation);
           // /* this is broken
            GameObject enemy = Instantiate(enemyTypes[rndEnemy], spawnPoints[i].position, spawnPoints[i].rotation) ;
            enemies.Add(enemy);
          //  */
        }


        print("Enemy Count: " + enemies.Count);
    }

    void SetUp()
    {
        switch(size)
        {
            case EnemySize.Small:
                transform.localScale = Vector3.one * scaleFactor;
                break;
            case EnemySize.Medium:
                transform.localScale = Vector3.one * scaleFactor;
                break;
            case EnemySize.Large:
                transform.localScale = Vector3.one * scaleFactor;
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("i"))
            SpawnEnemy();
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


}

public enum EnemySize
{
    Small,
    Medium,
    Large
}
