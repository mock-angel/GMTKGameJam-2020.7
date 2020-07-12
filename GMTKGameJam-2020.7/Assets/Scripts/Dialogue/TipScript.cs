using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipScript : MonoBehaviour
{
    
    public void OnClickedNextTip(){
    
        TutorialHandler.Instance.OnNextTip();
        
    }
    
    public void OnClickedPrevTip(){
    
        TutorialHandler.Instance.OnPreviousTip();
        
    }
}
