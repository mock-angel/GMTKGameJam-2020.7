using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    public static TutorialHandler Instance {get; private set;}
    
    public List<TipScript> tipScriptsList;
    
    private int tipCurrentlyAt = 0;
    
    private TipScript showingScript;
    
    public GameObject helpButton;
    public GameObject skipButton;
    
    void Awake(){
        Instance = this;
    }
    
    void Start(){
        if(tipScriptsList.Count != 0)
            showingScript = tipScriptsList[tipCurrentlyAt];
    }
    
    public void OnNextTip(){
        tipCurrentlyAt++;
        if(tipCurrentlyAt > tipScriptsList.Count - 1){
        
            Skip();
            
        }
        else{
            showingScript.gameObject.SetActive(false);
            tipScriptsList[tipCurrentlyAt].gameObject.SetActive(true);
            
            showingScript = tipScriptsList[tipCurrentlyAt];
        }
        
    }
    
    public void OnPreviousTip(){
        tipCurrentlyAt--;
        if(tipCurrentlyAt < 0){
        
            Skip();
            
        }
        else{
            showingScript.gameObject.SetActive(false);
            tipScriptsList[tipCurrentlyAt].gameObject.SetActive(true);
            
            showingScript = tipScriptsList[tipCurrentlyAt];
        }
        
    }
    
    public void OnClickedSkip(){
        Skip();
    }
    
    public void OnClickedHelp(){
        tipCurrentlyAt = 0;
        
        if(showingScript != null) showingScript.gameObject.SetActive(false);
        
        showingScript = tipScriptsList[0];
        
        if(showingScript != null) showingScript.gameObject.SetActive(true);
        
        gameObject.SetActive(true);
        
        helpButton.SetActive(false);
        skipButton.SetActive(true);
        
    }
    
    
    void Skip(){//Skip will basically reset everything to be used again.
        print("Skipped");
        tipCurrentlyAt = 0;
        
        if(showingScript != null) showingScript.gameObject.SetActive(false);
        
        showingScript = tipScriptsList[0];
        
        if(showingScript != null) showingScript.gameObject.SetActive(true);
        
        gameObject.SetActive(false);
        
        helpButton.SetActive(true);
        skipButton.SetActive(false);
    }
}
