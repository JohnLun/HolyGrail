using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningObstacle : MonoBehaviour
{
    public Transform respawnPoint;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private Vector3 constantVelocity;

    private void Start()
    {
        constantVelocity = new Vector3(0, -speed, 0);
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = new Vector3((float)(-4.837638), (float)-1.909238, (float)0.1347394);
    }
    private void Update()
    {
        transform.position += constantVelocity * Time.deltaTime;
        if(transform.position.y < screenBounds.y*2)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.position = respawnPoint.position;
            LifeManager.currentHealth -= 1;
            SoundManager.PlaySound("death");
            
        }
    }
}
