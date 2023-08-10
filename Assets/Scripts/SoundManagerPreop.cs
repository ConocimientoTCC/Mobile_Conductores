using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerPreop : MonoBehaviour
{
    public AudioSource questSound, itemCollect, confirmSound, correctSound;

    public bool muted = false;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayQuestSound()
    {
        questSound.Play();
    }

    public void PlayItemSound()
    {
        itemCollect.Play();
    }

    public void PlayConfirmSound()
    {
        confirmSound.Play();
    }

    public void PlayCorrectSound()
    {
        correctSound.Play();
    }
   

}