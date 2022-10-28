using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemySpawn;
    public GameObject enemyModel;

    public int atOnceMax = 3;
    private int atOnceCurr = 0;
    public int overAllMax = 9;
    private int overAllCurr = 0;

    //update is called once per frame
    void Update()
    {
        atOnceCurr = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (atOnceCurr < atOnceMax && overAllCurr < overAllMax)
        {
            var enemy = Instantiate(enemyModel);
            enemy.transform.position = enemySpawn.position;
            overAllCurr++;
        }
    }
}
