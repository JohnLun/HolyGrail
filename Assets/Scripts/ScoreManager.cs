using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreDisplay;
    public GameObject wings;
    public GameObject crosshair;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "";
    }

    public void updateScore()
    {
        scoreDisplay.text = "" + score;
        if (score == 10)
        {
            wings.SetActive(false);
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 1;
            GameObject.FindWithTag("MainCamera").GetComponent<PointAndShoot>().enabled = false;
            Cursor.visible = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 10)
        {
            wings.SetActive(false);
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 1;
            GameObject.FindWithTag("MainCamera").GetComponent<PointAndShoot>().enabled = false;
            Cursor.visible = true;
            crosshair.SetActive(false);
        }
    }
}
