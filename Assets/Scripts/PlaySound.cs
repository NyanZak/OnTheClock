using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioSource ButtonPress;

    // Use this script for different SFX

    public void ButtonPressSoundEffect()
    {
        ButtonPress.Play();
    }


}