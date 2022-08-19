using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject heart1, heart2, heart3;
    public static int currentHealth;
    public GameObject loseScreen;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 3;
        loseScreen.SetActive(false);
    }

    IEnumerator endScreen()
    {
        yield return new WaitForSeconds(2);
        loseScreen.SetActive(true);
        SoundManager.PlaySound("lose");
    }

    public void Update()
    {
        health = currentHealth;
        if(currentHealth == 2)
        {
            heart3.SetActive(false);
            //SoundManager.PlaySound("death");
        }
        else if(currentHealth == 1)
        {
            heart2.SetActive(false);
            //SoundManager.PlaySound("death");
        }
        else if(currentHealth == 0)
        {
            heart1.SetActive(false);
            StartCoroutine(endScreen());
            //SoundManager.PlaySound("death");
            //SoundManager.PlaySound("lose");
        }
    }
}
