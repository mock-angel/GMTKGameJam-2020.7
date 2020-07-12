using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip music;

    [SerializeField]
    private AudioClip clickBtn;

    [SerializeField]
    private AudioClip gameOverSFX;

    [SerializeField]
    private GameObject GOPanel;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject NextLevelPanel;

    public static bool GameIsPaused = false;

    public static GameManager Instance {get; private set;}

    public int level = 1; 

    void Awake(){
        Instance = this;
    }
    
    void Start()
    {
        Instance = this;
        Resume();
        
        GOPanel.SetActive(false);
        pausePanel.SetActive(false);
        AudioManager.AudioManagerProp.PlayMusic(music);

    }

    void Update()
    {

        CheckForPause();
        GameOver();
        TimerOver();

        


    }

    public void TimerOver()
    {
        if (Timer.DONE)
        {
            NextLevelPanel.SetActive(true);
            Time.timeScale = 0f;
           
        }
        

    }

    public void GameOver()
    {
        if (HealthBar.HP <= 0)
        {
            AudioManager.AudioManagerProp.PlaySFX(gameOverSFX,1);

            GOPanel.SetActive(true);

        }
        else
        {
            NextLevelPanel.SetActive(false);
            GOPanel.SetActive(false);
        }
    }

    public void CheckForPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }

    }

    public void Restart()
    {
        AudioManager.AudioManagerProp.PlaySFX(clickBtn);

        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GOPanel.SetActive(false);
        pausePanel.SetActive(false);

        HealthBar.HP = 100;
    }


    public void Resume ()
    {
        AudioManager.AudioManagerProp.PlaySFX(clickBtn);


        pausePanel.SetActive(false);
        NextLevelPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        AudioManager.AudioManagerProp.PlaySFX(clickBtn);


        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        AudioManager.AudioManagerProp.PlaySFX(clickBtn);

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }

    public void NextLevel()
    {
        AudioManager.AudioManagerProp.PlaySFX(clickBtn);

        

        Time.timeScale = 1f;
        GameIsPaused = false;
        GOPanel.SetActive(false);
        pausePanel.SetActive(false);
        NextLevelPanel.SetActive(false);

        HealthBar.HP = 100;
        
        if (level == 4)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(level + 1);
            
        }

    }

}
