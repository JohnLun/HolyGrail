using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI textDisplay;
    public GameObject continueBtn;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject anubis;
    public QuizManager quizManager;
    public GameObject yesChoice;
    public GameObject noChoice;
    public GameObject neutral;
    public GameObject quizContainer;
    public GameObject quizText;
    public GameObject wings;


    public void Start()
    {
        dialogueBox.SetActive(false);
        continueBtn.SetActive(false);
        yesChoice.SetActive(false);
        noChoice.SetActive(false);
        neutral.SetActive(false);
        quizContainer.SetActive(false);
        quizText.SetActive(false);
        wings.SetActive(false);
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void test()
    {
        Debug.Log("clicked");
    }

    public void disableAnubis()
    {
        
        if(index >= sentences.Length-1)
        {
            anubis.SetActive(false);
            yesChoice.SetActive(true);
            noChoice.SetActive(true);
            neutral.SetActive(true);
            quizManager.displayQuestion();
            quizContainer.SetActive(true);
            quizText.SetActive(true);
            PlayerMovement.PlayerMovementSpeed = 3.5f;
            dialogueBox.SetActive(false);
            continueBtn.SetActive(false);
            textDisplay.text = "";
        }
    }

    public void startSpawning()
    {
        if(index >= sentences.Length - 1)
        {
            wings.SetActive(true);
            GameObject.FindWithTag("MainCamera").GetComponent<PointAndShoot>().enabled = true;
            Cursor.visible = false;
            GameObject.FindWithTag("Spawner").GetComponent<EnemySpawner>().enabled = true;
            GameObject.FindWithTag("Spawner").GetComponent<EnemySpawner>().startSpawning();
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    public void NextSentence()
    {
        if(index < sentences.Length - 1)
        {
            Debug.Log("Clicked");
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else
        {
            dialogueBox.SetActive(false);
            PlayerMovement.PlayerMovementSpeed = 3.5f;
            continueBtn.SetActive(false);
            textDisplay.text = "";
        }
    }
}
