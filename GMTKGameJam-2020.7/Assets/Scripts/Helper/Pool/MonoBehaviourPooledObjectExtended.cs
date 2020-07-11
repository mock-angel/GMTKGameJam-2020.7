using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourPooledObjectExtended: MonoBehaviourPooledObject
{   
    [Tooltip("Will be set to null if no SpriteRenderer component is found. Untick this if none of your scripts are using this sprite renderer as it will save GetComponent calls in every Awake() call.")]
    public bool cacheSpriteRenderer;
    public bool cacheGameObject;
    
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    [HideInInspector]
    public GameObject gameObjectCache;
    
    void Awake(){
        if( cacheSpriteRenderer ) spriteRenderer = GetComponent<SpriteRenderer>();
        
        if( cacheGameObject ) gameObjectCache = gameObject;
    }
}
