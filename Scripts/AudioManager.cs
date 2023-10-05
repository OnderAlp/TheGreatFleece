using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if( _instance == null)
            {
                Debug.Log("AudioManager is null !");
            }
            return _instance;
        }
    }

    private AudioSource voiceOver;
    public AudioClip music;

    private void Awake()
    {
        _instance = this;
        voiceOver = GetComponent<AudioSource>();
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        Debug.Log("AM okey 1");
        if(voiceOver == null)
        {
            Debug.Log("Voiceover boþ");
        }
        voiceOver.clip = clipToPlay;
        if (voiceOver == null)
        {
            Debug.Log("Voiceover hala boþ");
        }
        voiceOver.Play();
        Debug.Log("AM okey 2");
    }

    //public void PlayMusic()
    //{
        //Debug.Log("AM okey 3");
        //music.Play();
        //Debug.Log("AM okey 4");
    //}
}


