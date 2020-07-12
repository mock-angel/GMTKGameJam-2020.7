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

    public static bool GameIsPaused = false;



    // Start is called before the first frame update
    void Start()
    {
        GOPanel.SetActive(false);
        pausePanel.SetActive(false);
        AudioManager.AudioManagerProp.PlayMusic(music);

    }

    void Update()
    {

        CheckForPause();
        GameOver();

        if (Timer.DONE)
        {
            SceneManager.LoadScene("Win");
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

        SceneManager.LoadScene(0);
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

        SceneManager.LoadScene(1);
        Time.timeScale = 1f;

    }

}
