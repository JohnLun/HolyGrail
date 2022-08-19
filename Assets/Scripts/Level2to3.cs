using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level2to3 : MonoBehaviour
{
    public GameObject levelTransition;
    public Transform respawnPoint;
    public GameObject player;
    public GameObject level2;
    public GameObject filler;
    public GameObject level2Bg;
    public GameObject level3Bg;
    public GameObject level1Bg;
    public Dialogue dialogue;
    public GameObject dialogueBox;
    public TextMeshProUGUI textDisplay;
    public GameObject continueBtn;
    public GameObject level3;

    //public GameObject mainCam;//l3Cam;
    /*public Dialogue dialogue;
    public GameObject dialogueBox;
    public TextMeshProUGUI textDisplay;
    public GameObject continueBtn;*/

    // Start is called before the first frame update
    void Start()
    {
        levelTransition.SetActive(false);
        level3Bg.SetActive(false);
        //GameObject.FindWithTag("Spawner").GetComponent<EnemySpawner>().enabled = false;
        //l3Cam.SetActive(false);
    }



    public IEnumerator transition()
    {
        PlayerMovement.PlayerMovementSpeed = 0;
        yield return new WaitForSeconds(3);
        levelTransition.SetActive(true);
        level2.SetActive(false);
        level3.SetActive(true);
        player.transform.position = respawnPoint.position;
        level2Bg.SetActive(false);
        filler.SetActive(false);
        yield return new WaitForSeconds(3);
        levelTransition.SetActive(false);
        level3Bg.SetActive(true);
        level1Bg.SetActive(false);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraMovement>().enabled = false;
        Vector3 pos = new Vector3(-3.21f, -22.16f, -5f);
        Camera.main.gameObject.transform.position = pos;
        GameObject.FindWithTag("Spawner").GetComponent<EnemySpawner>().enabled = false;

        dialogue.NextSentence();
        dialogueBox.SetActive(true);
        continueBtn.SetActive(true);
        //mainCam.SetActive(false);
        //l3Cam.SetActive(true);
        /*dialogue.NextSentence();
        dialogueBox.SetActive(true);
        continueBtn.SetActive(true);*/
        //PlayerMovement.PlayerMovementSpeed = 3.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            StartCoroutine(transition());
            PlayerMovement.PlayerMovementSpeed = 3.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
