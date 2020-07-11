using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]    
//public class Pool
//{
//    public string tag;
//    public GameObject prefab;
//    public int size;
//}

//public class PoolQueue<T> : Queue
//{
//    public Pool poolParent;
//}

public class SingleObjectPooler : MonoBehaviour
{
    public Pool pool;
    public PoolQueue<GameObject> poolQueue;
    
    void Awake(){
        if(poolQueue == null) poolQueue = new PoolQueue<GameObject>();
        else return;
        
        for(int j = 0;j<pool.size; j++)
        {
            GameObject obj = Instantiate(pool.prefab, gameObject.transform);
            obj.SetActive(false);
            
            MonoBehaviourPooledObject PooledObjectScript = obj.GetComponent<MonoBehaviourPooledObject>();
            
            if(PooledObjectScript != null) {
                PooledObjectScript.SetQueue(poolQueue);
            }
            
            poolQueue.Enqueue(obj);
        }
        
        poolQueue.poolParent = pool;
    }
    
    GameObject CreateObjectSinlge(){
        GameObject obj = Instantiate(pool.prefab, gameObject.transform);
        obj.SetActive(false);
        
        MonoBehaviourPooledObject PooledObjectScript = obj.GetComponent<MonoBehaviourPooledObject>(); 
        
        if(PooledObjectScript != null) PooledObjectScript.SetQueue(poolQueue);
        else {
            Destroy(obj);
            return null;
        }
        PooledObjectScript.WithdrawToPool();
        return obj;
    }
    
    GameObject CreateObjectBlankSingle(){
        GameObject obj = Instantiate(pool.prefab, gameObject.transform);
        obj.SetActive(false);
        
        MonoBehaviourPooledObject PooledObjectScript = obj.GetComponent<MonoBehaviourPooledObject>(); 
        
        if(PooledObjectScript != null) PooledObjectScript.SetQueue(poolQueue);
        else {
            return null;
        }
        return obj;
    
    }
    public GameObject SpawnFromPoolSingle(Vector3 position, Quaternion rotation)
    {
//        if(!poolDictionary.ContainsKey(tag)){
//            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
//            return null;
//        }
        
//        PoolQueue<GameObject> poolQueue = poolDictionary[tag];
        GameObject objectToSpawn;
        if(poolQueue.Count>0)
            objectToSpawn = (GameObject) poolQueue.Dequeue();
        else //return null;
            objectToSpawn = CreateObjectBlankSingle();
         
        IPooledObject ObjectInterface = objectToSpawn.GetComponent<IPooledObject>(); //Get rid of GetComponent call.
        if(ObjectInterface != null) ObjectInterface.OnObjectSpawn();
        
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);
        
        return objectToSpawn;
    }
    
//    public void WithdrawToPool(string tag, GameObject obj){
//        poolDictionary[tag].Enqueue(obj);
//    }
}
