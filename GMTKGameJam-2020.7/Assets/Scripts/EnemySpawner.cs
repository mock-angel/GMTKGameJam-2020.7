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

    int totalTicks = 0;

    [SerializeField]
    GameObject Cobwebs;

    public List<int> levelsAfterTick;

    void Start(){
        //SpawnRangedEnemy();
    }

    void Update()
    {
        if(GameStarted && !PlayerMovement.Instance.dead){
            
            totalTime += Time.deltaTime;
            if(totalTime >= TickLength){
                totalTime -= TickLength;


                totalTicks++;

                CalculateLevel();

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

    int level;

    void CalculateLevel(){
        
        level = 0;

        for(int i = 0; i< levelsAfterTick.Count; i++){
            int levelTickRequirement = levelsAfterTick[i];

            if(totalTicks > levelTickRequirement) level++;
        }
    }

    //Manage Enemy epawn here.
    void SpawnMeleeEnemy(){
        GameObject obj = objectPooler.SpawnFromPool(meleeEnemyString, transform.position, Quaternion.identity);
        //GameObject obj = Instantiate(EnemyPrefab);
        obj.GetComponent<EnemyController>().targetPosition = PlayerMovement.Instance.transform;
    }

    void SpawnRangedEnemy(){
        GameObject obj = objectPooler.SpawnFromPool(rangedEnemyString, transform.position, Quaternion.identity);
        //GameObject obj = Instantiate(EnemyPrefab);
        obj.GetComponent<EnemyController>().targetPosition = PlayerMovement.Instance.transform;
    }
    
    int lowerLimit = 0;
    int upperLimit = 0;

    int maxUpperLimit = 7;

    void CauldronEvent()
    {
        ScreenTint.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        upperLimit = level;

        int selectedNum = Random.Range(lowerLimit, upperLimit);

        switch (selectedNum)
        {
            case (0):
                SpawnMeleeEnemy();
                AudioManager.AudioManagerProp.PlaySFX(cauldronBubbling);
                break;
            
            case (1):
                SpawnRangedEnemy();
                AudioManager.AudioManagerProp.PlaySFX(cauldronBubbling);
                break;

            case (2):
                SpawnMeleeEnemy();
                AudioManager.AudioManagerProp.PlaySFX(cauldronBubbling);
                break;
            case (3):
                //put poison tiles everywhere
                Cobwebs.active = !Cobwebs.active;
                break;
            case (4):
                //put cobwebs everywhere
                Cobwebs.active = !Cobwebs.active;
                break;
            case (5):
                Sign = (Random.Range(1, 2) == 1 ? 1 : -1);
                Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(Camera.main.transform.localRotation.x, Camera.main.transform.localRotation.y,Random.Range(0,360)));

                AudioManager.AudioManagerProp.PlaySFX(cauldronBubbling);
                break;
            case (6):
                FuckeryLevel++;
                //print("FUCKERY LEVEL : " + FuckeryLevel);
                break;
        }

    }

    void SetOnFire(){

    }

    void SpillPoison(){

    }

    void LitterCobWebs(){

    }
}
