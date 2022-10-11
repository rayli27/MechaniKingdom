using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region Static Instace
    private static AudioManager instance;

    public static AudioManager Instance{

        get{

            if (instance == null){

                instance = FindObjectOfType<AudioManager>();
                if (instance == null){
                    instance = new GameObject("AudioManagerRun", typeof(AudioManager)).GetComponent<AudioManager>();
                }

            }

            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    #endregion

    #region Fields
    private AudioSource musicSource;
    private AudioSource sfxSource;
    #endregion

    private void Awake(){

        DontDestroyOnLoad(this.gameObject);

        sfxSource = this.gameObject.AddComponent<AudioSource>();
        musicSource = this.gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;

    }

    public void PlayMusic(AudioClip music, float volume){

        musicSource.clip = music;
        musicSource.volume = 0.5f;
        musicSource.Play();

    }
    public void PlaySound(AudioClip sound, float volume){

        sfxSource.PlayOneShot(sound, volume);

    }
}