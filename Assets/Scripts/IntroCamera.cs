using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCamera : MonoBehaviour
{
    public GameObject intro;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
   // public GameObject credits;
    public GameObject pauseScreen;
    public bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        intro.SetActive(true);
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                pauseScreen.SetActive(false);
                isPaused = !isPaused;
            }
            else
            {
                pauseScreen.SetActive(true);
                isPaused = !isPaused;
            }
        }
    }

    public void onStart()
    {
        Time.timeScale = 1;
        level1.SetActive(true);
        intro.SetActive(false);
        SoundManager.PlaySound("thunderAmbient");
        hide();
    }

    public void onCredits()
    {
        intro.SetActive(false);
        //credits.SetActive(true);
        hide();
    }

    public void onExit()
    {
        Application.Quit();
    }

    public void onResume()
    {
        isPaused = false;
        pauseScreen.SetActive(false);
    }

    private void hide()
    {

    }
    // Update is called once per frame
}
