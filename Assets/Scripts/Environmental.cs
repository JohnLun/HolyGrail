using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environmental : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            LifeManager.currentHealth -= 1;
            player.transform.position = respawnPoint.position;
            SoundManager.PlaySound("death");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
