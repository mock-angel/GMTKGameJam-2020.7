using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellsEnum{
    FIRE,
    ICE,
    WIND
}

public class Potion : MonoBehaviour
{
    public GameObject rangeCircle;

    public SpellsEnum spellType;

    [Range(0, 10)]
    public float SpellDuration = 5f;

    public KeyCode keyCode;

    public void CasteSpell(){
        StartCoroutine("StartCasteSpells");
    }

    IEnumerator StartCasteSpells(){

        //Activate spell.
        rangeCircle.SetActive(true);

        switch (spellType){
            case (SpellsEnum.FIRE): 
                StartFireSpell(true);
                break;
            case (SpellsEnum.ICE): 
                StartFireSpell(true);
                break;
            case (SpellsEnum.WIND): 
                StartFireSpell(true);
                break;
        }

        //Wait for duration.
        yield return new WaitForSeconds(SpellDuration);

        //Deactivate spell after waiting.
        rangeCircle.SetActive(false);

        switch(spellType){
            case (SpellsEnum.FIRE): 
                StartFireSpell(false);
                break;
            case (SpellsEnum.ICE): 
                StartFireSpell(false);
                break;
            case (SpellsEnum.WIND): 
                StartFireSpell(false);
                break;
        }
    }

    void StartFireSpell(bool enable){
        if(enable){
            //start spell
        }
        else{
            //stop spell
        }
    }

    void StartIceSpell(bool enable){
        if(enable){
            //start spell
        }
        else{
            //stop spell
        }
    }

    void StartWindSpell(bool enable){
        if(enable){
            //start spell
        }
        else{
            //stop spell
        }
    }
}
