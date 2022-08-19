using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployLightning : MonoBehaviour
{
    public GameObject lightningPrefab;
    public float respawnTime;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = new Vector3((float)(-4.837638), (float)-1.909238, (float)0.1347394);
        StartCoroutine(lightningWave());
    }

    private void spawnLightning()
    {
        GameObject lightning = Instantiate(lightningPrefab) as GameObject;
        lightning.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * -2);
    }

    IEnumerator lightningWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnLightning();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
