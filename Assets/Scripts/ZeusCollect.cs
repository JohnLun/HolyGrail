using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeusCollect : MonoBehaviour
{
    public Transform secondLevel;
    public GameObject player;
    public GameObject levelTransition;
    public GameObject zeus;
    // Start is called before the first frame update
    void Start()
    {
        //levelTransition.SetActive(false);
    }

    IEnumerator removeTransition()
    {
        yield return new WaitForSeconds(4);
        levelTransition.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //levelTransition.SetActive(true);
            //player.transform.position = secondLevel.position;
            InventoryManager.numRelics++;
            zeus.SetActive(false);
            SoundManager.PlaySound("collect");
            //SoundManager.PlaySound("collect");
            //StartCoroutine(removeTransition());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
