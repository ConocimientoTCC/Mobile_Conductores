using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource click_1, click_2;    // Start is called before the first frame update
    public AudioSource error_1, error_2;
    public AudioSource success_1, success_2;
    public AudioSource playSound;
    public AudioSource bgMusic;

    public bool muted = false;
    public Button btnMusic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClick1()
    {
        click_1.Play();
    }
    public void PlayClick2()
    {
        click_2.Play();
    }
    public void PlayError1()
    {
        error_1.Play();
    }
    public void PlayError2()
    {
        error_2.Play();
    }

    public void PlaySuccess1()
    {
        success_1.Play();
    }

    public void PlayPlay()
    {
        playSound.Play();
    }

    public void SwitchBGMusic()
    {
        if(muted == false)
        {
            muted = true;
            bgMusic.Pause();
            btnMusic.image.sprite = Resources.Load<Sprite>("images/pause_music_off");
        }
        else
        {
            muted = false;
            bgMusic.UnPause();
            btnMusic.image.sprite = Resources.Load<Sprite>("images/pause_music_on");
        }
        
    }
    
}
