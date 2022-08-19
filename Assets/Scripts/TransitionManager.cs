using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionManager : MonoBehaviour
{
    public GameObject levelTransition;
    public Transform respawnPoint;
    public GameObject player;
    public GameObject level1Bg;
    public GameObject level1;
    public GameObject level2Bg;
    public GameObject filler;
    public Dialogue dialogue;
    public GameObject dialogueBox;
    public TextMeshProUGUI textDisplay;
    public GameObject continueBtn;
    public GameObject level2;
    
    // Start is called before the first frame update
    void Start()
    {
        levelTransition.SetActive(false);
        level2Bg.SetActive(false);
        filler.SetActive(false);
    }

    

    IEnumerator transition()
    {
        PlayerMovement.PlayerMovementSpeed = 0;
        yield return new WaitForSeconds(3);
        levelTransition.SetActive(true);
        level1.SetActive(false);
        level1Bg.SetActive(false);
        level2.SetActive(true);
        player.transform.position = respawnPoint.position;
        SoundManager.volume = 0.1f;
        SoundManager.PlaySound("desertAmbient");
        level2Bg.SetActive(true);
        filler.SetActive(true);
        yield return new WaitForSeconds(3);
        levelTransition.SetActive(false);
        dialogue.NextSentence();
        dialogueBox.SetActive(true);
        continueBtn.SetActive(true);

        //PlayerMovement.PlayerMovementSpeed = 3.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Zeus"))
        {
            StartCoroutine(transition());

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
