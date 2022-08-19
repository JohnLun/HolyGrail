using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public GameObject scales;
    public GameObject neutral;
    public GameObject oneWrong;
    public GameObject twoWrong;
    public GameObject oneRight;
    public GameObject twoRight;
    public Transform respawnPoint;
    public TextMeshProUGUI text;
    public GameObject player;
    public GameObject noChoice;
    public GameObject yesChoice;
    public float typingSpeed;
    public GameObject quizContainer;
    public GameObject door;

    public int score;
    public bool[] answers;
    public string[] questions;
    private int index;
    public string[] victory;
    public string[] loss;
    // Start is called before the first frame update
    void Start()
    {
        neutral.SetActive(false);
        oneWrong.SetActive(false);
        twoWrong.SetActive(false);
        oneRight.SetActive(false);
        twoRight.SetActive(false);
        door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator type()
    {
        text.text = "";
        if(index <= questions.Length-1)
        {
            foreach (char letter in questions[index].ToCharArray())
            {
                text.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        } else
        {
            noChoice.SetActive(false);
            yesChoice.SetActive(false);
            if (score >= 0)
            {
                foreach (char letter in victory[0].ToCharArray())
                {
                    text.text += letter;
                    yield return new WaitForSeconds(typingSpeed);
                }
            }
            else
            {
                foreach (char letter in loss[2].ToCharArray())
                {
                    text.text += letter;
                    yield return new WaitForSeconds(typingSpeed);
                }
                yield return new WaitForSeconds(3);
                LifeManager.currentHealth -= 1;
                if (LifeManager.currentHealth != 0)
                {
                    
                    yield return new WaitForSeconds(4);
                    text.text = "";
                    foreach (char letter in loss[0].ToCharArray())
                    {
                        text.text += letter;
                        yield return new WaitForSeconds(typingSpeed);
                    }
                    
                    yield return new WaitForSeconds(4);
                    text.text = "";
                    foreach (char letter in loss[1].ToCharArray())
                    {
                        text.text += letter;
                        yield return new WaitForSeconds(typingSpeed);
                    }
                    yield return new WaitForSeconds(3);
                    
                    
                }
                
                //levelTransition.transition();
            }
            text.text = "";
            quizContainer.SetActive(false);
            InventoryManager.numRelics++;
            SoundManager.PlaySound("collect");
            door.SetActive(true);
        }
        
    }

    public void displayQuestion()
    {
        StartCoroutine(type());
        if (score == 0)
        {
            neutral.SetActive(true);
            oneWrong.SetActive(false);
            twoWrong.SetActive(false);
            oneRight.SetActive(false);
            twoRight.SetActive(false);
        }
        else if (score == 1)
        {
            neutral.SetActive(false);
            oneWrong.SetActive(false);
            twoWrong.SetActive(false);
            oneRight.SetActive(true);
            twoRight.SetActive(false);
        }
        else if (score == 2)
        {
            neutral.SetActive(false);
            oneWrong.SetActive(false);
            twoWrong.SetActive(false);
            oneRight.SetActive(false);
            twoRight.SetActive(true);
        }
        else if (score == -1)
        {
            neutral.SetActive(false);
            oneWrong.SetActive(true);
            twoWrong.SetActive(false);
            oneRight.SetActive(false);
            twoRight.SetActive(false);
        }
        else if (score == -2)
        {
            neutral.SetActive(false);
            oneWrong.SetActive(false);
            twoWrong.SetActive(true);
            oneRight.SetActive(false);
            twoRight.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Yes"))
        {
            if (answers[index])
            {
                if(score != 2)
                    score++;
            } else
            {
                if(score != -2)
                    score--;
            }
            index++;
            player.transform.position = respawnPoint.position;
            displayQuestion();
        }
        else if(collision.CompareTag("No"))
        {
            if (!answers[index])
            {
                if(score != 2)
                    score++;
            }
            else
            {
                if(score != -2)
                    score--;
            }
            index++;
            player.transform.position = respawnPoint.position;
            displayQuestion();
        }
        
    }

}
