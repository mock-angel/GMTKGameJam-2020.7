using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{

    #region Static Instance
    private static AudioManager audioManager;
    public static AudioManager AudioManagerProp {

        get
        {
            if (audioManager == null)
            {

                audioManager = FindObjectOfType<AudioManager>();
                if (audioManager == null)
                {
                    audioManager = new GameObject("Spawned AudioManger", typeof(AudioManager)).GetComponent<AudioManager>();
                }
            }

            return audioManager;
        }
        
        private set
        {
            audioManager = value;
        }
       
       }
    #endregion

    #region Fields
    private AudioSource musicSource;
    private AudioSource musicSource2;
    private AudioSource sfxSource;

    private bool firstMusicSourceIsPlaying;


    #endregion

    private void Awake()
    {
        //Make sure we dont destory this instance
        DontDestroyOnLoad(this.gameObject);

        //Create audio sources, and save them as references
        musicSource = this.gameObject.AddComponent<AudioSource>();
        musicSource2 = this.gameObject.AddComponent<AudioSource>();
        sfxSource = this.gameObject.AddComponent<AudioSource>();

        //Loop the music tracks
        musicSource.loop = true;
        musicSource2.loop = true;

    }

    public void PlayMusic(AudioClip audioClip)
    {
        //Determines which source is active
        AudioSource audioSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;

        audioSource.clip = audioClip;
        audioSource.volume = 1;
        audioSource.Play();

    }
    public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1.0f)
    {
        //Determines which source is active
        AudioSource audioSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;


        StartCoroutine(UpdateMusicWithFade(audioSource, newClip, transitionTime));
    }
    public void PlayMusicWithCrossFade(AudioClip audioClip, float transitionTime = 1.0f)
    {
        //Determines which source is active
        AudioSource audioSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;
        AudioSource newSource = (firstMusicSourceIsPlaying) ? musicSource2 : musicSource;

        //Swap active source with new
        firstMusicSourceIsPlaying = !firstMusicSourceIsPlaying;

        newSource.clip = audioClip;
        newSource.Play();
        StartCoroutine(UpdateMusicWithCrossFade(audioSource, newSource, transitionTime));
    }

    private IEnumerator UpdateMusicWithCrossFade(AudioSource original, AudioSource newSource, float transtionTime)
    {
        float t = 0.0f;

        for (t = 0.0f; t < transtionTime; t += Time.deltaTime)
        {

            original.volume = (1 - (t / transtionTime));
            newSource.volume = (t / transtionTime);
            yield return null;
        }

        original.Stop();
    }


    private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip newClip, float transtionTime)
    {
        //Make sure the soruce is active and playing
        if(!activeSource.isPlaying)
        {
            activeSource.Play();

            float t = 0.0f;

            //Fade out
            for (t = 0; t < transtionTime; t += Time.deltaTime)
            {

                activeSource.volume = (1 - (t / transtionTime));
                yield return null;
            }

            activeSource.Stop();
            activeSource.clip = newClip;
            activeSource.Play();

            //Fade in
            for (t = 0; t < transtionTime; t += Time.deltaTime)
            {

                activeSource.volume = (t / transtionTime);
                yield return null;
            }

        }
    }


    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    /// overload
    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void SetMusicVolme(float volume)
    {
        musicSource.volume = volume;
        musicSource2.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }    

}
