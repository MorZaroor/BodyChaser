using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource bgmSource;
    public AudioClip startBGM;
    public AudioClip midGameBGM;
    public AudioClip eventSound;

    public AudioSource seSource;
    public AudioClip hitSound;
    public AudioClip speedSound;
    public AudioClip invincibleSound;
    
    void Start()
    {
        bgmSource = GetComponent<AudioSource>();
        bgmSource.clip = startBGM;
        PlayBGM();
    }

    public void PlayBGM()
    {
        bgmSource.Play();
    }
    public void ChangeBGM(AudioClip newClip)
    {
        bgmSource.Stop();
        bgmSource.clip = newClip;
        bgmSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        seSource.PlayOneShot(clip);
    }

}
