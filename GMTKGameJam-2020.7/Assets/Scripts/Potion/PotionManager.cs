using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    public static PotionManager Instance {get; private set;}
    
    public List<Potion> potionList;

    public bool isSpellActive;

    void Update(){

        if(isSpellActive) return;

        for(int i = 0; i< potionList.Count; i++){
            if (Input.GetKeyDown(potionList[i].keyCode))
            {
                // do some stuff here
                potionList[i].CasteSpell();
            }
        }
    }

}
