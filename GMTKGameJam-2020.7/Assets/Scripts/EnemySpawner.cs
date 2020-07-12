using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private AudioClip cauldronBubbling;


    public bool GameStarted = false;

    [Tooltip("How much time to wait till tick ends and enemy spawns again.")]
    [Range(0, 5)]
    public float TickLength = 1;

    [Tooltip("How much enemy to spawn during next tick.")]
    [Range(0, 20)]
    [SerializeField] private float EnemySpawnedPerTick = 1;

    [SerializeField] private ObjectPooler objectPooler;


    [SerializeField] private string meleeEnemyString = "Melee Golem";
    [SerializeField] private string rangedEnemyString = "Ranged Wizard";

    private float totalTime = 0;
    int Sign = 1;

    public Image ScreenTint;
    float FuckeryLevel = 3;
    int TImer;

    void Update()
    {
        TImer++;
        if(GameStarted){
            
            totalTime += Time.deltaTime;
            if(totalTime >= TickLength){
                totalTime -= TickLength;

                //SpawnEnemy();
                CauldronEvent();

            }
        }
        
        if(Mathf.Round(Camera.main.transform.eulerAngles.z) != 0)
        {
            //Camera.main.transform.localRotation = Quaternion.Euler( new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z + 2*Sign));
        }

        float temp = FuckeryLevel * 0.01f;

        ScreenTint.color += new Color(0,0,0,-0.01f);


  
        
    }

    //Manage Enemy epawn here.
    void SpawnEnemy(){
        GameObject obj = objectPooler.SpawnFromPool(meleeEnemyString, transform.position, Quaternion.identity);
        //GameObject obj = Instantiate(EnemyPrefab);
        obj.GetComponent<EnemyController>().targetPosition = PlayerMovement.Instance.transform;
    }

    void CauldronEvent()
    {
        ScreenTint.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        switch (Random.Range(1, 7))
        {
            case (1):
                SpawnEnemy();
                AudioManager.AudioManagerProp.PlaySFX(cauldronBubbling);
                break;
            case (2):
                //set everything on fire
                break;
            case (3):
                //put poison tiles everywhere
                break;
            case (4):
                //put cobwebs everywhere
                break;
            case (5):
                Sign = (Random.Range(1, 2) == 1 ? 1 : -1);
                Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(Camera.main.transform.localRotation.x, Camera.main.transform.localRotation.y,Random.Range(0,360)));

                AudioManager.AudioManagerProp.PlaySFX(cauldronBubbling);
                break;
            case (6):
                FuckeryLevel++;
                print("FUCKERY LEVEL : " + FuckeryLevel);

                
                break;


        }

                






    }
}
