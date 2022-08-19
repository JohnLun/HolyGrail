using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Dialogue dialogueManager;
    public GameObject visualCue;
    public GameObject textDisplay;
    public GameObject continueBtn;
    public GameObject dialogueBox;


    void OnMouseDown()
    {
        PlayerMovement.PlayerMovementSpeed = 0;
        dialogueManager.NextSentence();
        textDisplay.SetActive(true);
        continueBtn.SetActive(true);
        dialogueBox.SetActive(true);
        Debug.Log("Mouse down");
        Destroy(visualCue);
    }
    // Start is called before the first frame update
    
}
