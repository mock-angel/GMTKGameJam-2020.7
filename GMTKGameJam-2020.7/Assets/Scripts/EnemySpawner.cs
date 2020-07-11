using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool GameStarted = false;

    [Tooltip("How much time to wait till tick ends and enemy spawns again.")]
    [Range(0, 5)]
    public float TickLength = 1;

    [Tooltip("How much enemy to spawn during next tick.")]
    [Range(0, 20)]
    public float EnemySpawnedPerTick = 1;

    [SerializeField] private GameObject EnemyPrefab;

    private float totalTime = 0;

    void Update()
    {
        if(GameStarted){
            
            totalTime += Time.deltaTime;
            if(totalTime >= TickLength){
                totalTime -= TickLength;

                SpawnEnemy();
            }
        }
    }

    //Manage Enemy epawn here.
    void SpawnEnemy(){

        GameObject obj = Instantiate(EnemyPrefab);
        obj.GetComponent<EnemyController>().targetPosition = PlayerMovement.Instance.transform;
    }
}
