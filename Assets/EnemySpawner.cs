using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject angelPrefab;

    public static int numAngels;
    // Start is called before the first frame update

    private float angleInterval = 5f;
    void Start()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        while(ScoreManager.score != 10)
        {
            yield return new WaitForSeconds(angleInterval);
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
            spawnEnemy(interval, enemy);
        }
        
    }

    public void startSpawning()
    {
       
        StartCoroutine(spawnEnemy(angleInterval, angelPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.score == 10)
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Angel");
            foreach(GameObject obj in taggedObjects) {
                Destroy(obj);
            }
        }
    }
}
