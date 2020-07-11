using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourPooledObject: MonoBehaviour, IPooledObject
{
    public PoolQueue<GameObject> queueBelongsTo;
    
    [HideInInspector]
    public SpriteRenderer cachedSpriteRenderer;
    
    public void SetQueue(PoolQueue<GameObject> queue){
        queueBelongsTo = queue;
    }
    
    public void OnFirstCreated(){
        cachedSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void WithdrawToPool(){
        gameObject.SetActive(false);
        
        if(queueBelongsTo != null) queueBelongsTo.Enqueue(gameObject);
        else {
            Debug.LogWarning("WithdrawToPool unsuccessful: queueBelongsTo is null");
            return;
        }
        
        if(cachedSpriteRenderer != null){
            cachedSpriteRenderer.flipX = false;
            cachedSpriteRenderer.flipY = false;
        }
    }
    
    public void OnObjectSpawn(){
        
    }
}
