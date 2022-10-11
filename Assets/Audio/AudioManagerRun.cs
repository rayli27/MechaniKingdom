using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerRun : MonoBehaviour{

    public AudioSource buttonSound;
    [SerializeField] private AudioClip buttonHover;
    [SerializeField] private AudioClip doorClose;
    [SerializeField] private AudioClip doorOpen;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip laser;
    [SerializeField] private AudioClip spell;
    [SerializeField] private AudioClip swoosh;
    [SerializeField] private AudioClip trumpets;
    [SerializeField] private AudioClip zap;

    [SerializeField] private AudioClip music1;
    [SerializeField] private AudioClip music2;

    public void playButtonSound(AudioSource sound)
    {

        sound.Play();

    }

    private void Update() {
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0))
            AudioManager.Instance.PlaySound(swoosh, 0.5f);
        if (Input.GetKeyDown(KeyCode.Mouse1))
            AudioManager.Instance.PlaySound(spell, 0.5f);
        */
     }
        
}
