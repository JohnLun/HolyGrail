using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory1, inventory2, inventory3;
    public GameObject relic1, relic2, relic3;
    public static int numRelics;
    public GameObject victoryScreen;
    // Start is called before the first frame update
    void Start()
    {
        numRelics = 0;
        relic1.SetActive(false);
        relic2.SetActive(false);
        relic3.SetActive(false);
        victoryScreen.SetActive(false);
    }

    IEnumerator winScreen()
    {
        yield return new WaitForSeconds(3);
        victoryScreen.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(numRelics == 1)
        {
            relic1.SetActive(true);
            inventory1.SetActive(false);
            //SoundManager.PlaySound("collect");
        } else if(numRelics == 2)
        {
            relic2.SetActive(true);
            inventory2.SetActive(false);
            //SoundManager.PlaySound("collect");
        } else if(numRelics == 3)
        {
            relic3.SetActive(true);
            inventory3.SetActive(false);
            StartCoroutine(winScreen());
            //SoundManager.PlaySound("collect");
            //SoundManager.PlaySound("win");
        }
    }
}
