using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public GameObject player;
    PlayerCtrl playerCtrl;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ground")&&playerCtrl.isJumping)
        {
            playerCtrl.isJumping = false;
        }
        if(other.gameObject.CompareTag("Platform")&&playerCtrl.isJumping)
        {
            playerCtrl.isJumping = false;
            player.transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
