using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class potionstatic : MonoBehaviour
{
    [SerializeField]
    private AudioClip firePotionSFX;

    [SerializeField]
    private AudioClip IcePotionSFX;

    public SpriteRenderer[] Effect;

    public Slider[] CoolDown;

    public float[] CoolDownSeconds;
    public float[] PotUseSeconds;

    public Color Fire, Ice, Air;
    Color[] PotCol = new Color[3];

    public KeyCode[] PotionKeys;

    CircleCollider2D C;

    public static potionstatic Instance {get; private set;}

    public GameObject IndFire;
    public Transform Next;
    public GameObject FireParent;

    void Awake(){
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        PotCol[0] = Fire;
        PotCol[1] = Ice;
        PotCol[2] = Air;

        C = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {



        for(int i = 0;i < CoolDown.Length; i++)
        {
            
            CoolDown[i].value = (CoolDown[i].value < 1? CoolDown[i].value + ((float)1 / (float)60/CoolDownSeconds[i]) : 1);
            if (Input.GetKeyDown(PotionKeys[i]) && CoolDown[i].value >= 1)
            {
                CoolDown[i].value = 0;
                Use(i + 1);
            }

            if (CoolDown[i].value >= PotUseSeconds[i] / CoolDownSeconds[i])
            {
                Effect[i].color = new Color(1,0,0,0);

            }
        }

        if (Input.GetKeyDown(KeyCode.J) && CoolDown[0].value >= 1 )
        {
            AudioManager.AudioManagerProp.PlaySFX(firePotionSFX);
        }
        if (Input.GetKeyDown(KeyCode.K) && CoolDown[0].value >= 1)
        {
            AudioManager.AudioManagerProp.PlaySFX(IcePotionSFX);
        }




    }

    public void Check(int ID)
    {
        if (CoolDown[ID - 1].value >= 1)
        {
            CoolDown[ID - 1].value = 0;
            Use(ID);
        }
    }

    public void Use(int ID)
    {

        Instantiate(IndFire, Next.position, new Quaternion(0, 0, 0, 1), FireParent.transform);

        Effect[ID - 1].color = PotCol[ID - 1];

        Effect[ID - 1].GetComponent<PotSelect>().DoHighlight = true;

    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && CoolDown[0].value == 1)
        {
            collision.transform.Find("OnFire").GetComponent<SpriteRenderer>().color = Color.white;
        }
    }*/

    public void OnTriggeredFireCircle(Collider2D collision){
        if(collision.tag == "Enemy" && CoolDown[0].value <= PotUseSeconds[0] / CoolDownSeconds[0])
        {
            collision.transform.Find("OnFire").GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
