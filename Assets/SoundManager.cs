using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip footstep, collect, death, desertAmbient, thunderAmbient, lose, win, holy, jump;
    static AudioSource audioSrc;
    public static float volume = 1;
    // Start is called before the first frame update
    void Start()
    {
        footstep = Resources.Load<AudioClip>("footstepV2");
        collect = Resources.Load<AudioClip>("collect");
        death = Resources.Load<AudioClip>("death");
        desertAmbient = Resources.Load<AudioClip>("desertAmbient");
        thunderAmbient = Resources.Load<AudioClip>("thunderAmbient");
        jump = Resources.Load<AudioClip>("jump");
        lose = Resources.Load<AudioClip>("lose");
        win = Resources.Load<AudioClip>("win");
        holy = Resources.Load<AudioClip>("holy");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = volume;    
    }

    public static void PauseSound(string clip)
    {
        switch(clip)
        {
            case "footstep":
                audioSrc.Pause();
                break;
        }
    }

    public static void LoopSound(string clip)
    {
        switch(clip)
        {
            case "footstep":
                audioSrc.clip = footstep;
                audioSrc.loop = true;
                break;
        }
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "footstep":
                audioSrc.PlayOneShot(footstep);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "death":
                audioSrc.PlayOneShot(death);
                break;
            case "lose":
                audioSrc.PlayOneShot(lose);
                break;
            case "win":
                audioSrc.PlayOneShot(win);
                break;
            case "collect":
                audioSrc.PlayOneShot(collect);
                break;
            case "thunderAmbient":
                audioSrc.PlayOneShot(thunderAmbient);
                break;
            case "desertAmbient":
                audioSrc.PlayOneShot(desertAmbient);
                break;
            case "holy":
                audioSrc.PlayOneShot(holy);
                break;
        }
    }
}
