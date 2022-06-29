using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hoverFX;
    public AudioClip clickFX;

    public void HoverSound() 
    {
        audioSource.PlayOneShot(hoverFX);
    }

    public void ClickSound() 
    {
        audioSource.PlayOneShot(clickFX);
    }
}
