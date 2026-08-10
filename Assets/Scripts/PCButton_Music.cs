using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCButton_Music : MonoBehaviour
{
    public AudioSource click_sound;

    public void Play_click_Sound()
    {
        click_sound.Play();
    }
}
