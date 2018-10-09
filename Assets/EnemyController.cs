using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    PlayerController pc;
    float velocity = 2.0f;

    private void Start()
    {
       // transform.position = new Vector2(1080, Random.Range(1, 800));
        pc = GameManager.instance.player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        float speed = velocity * Time.deltaTime;
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pc.Damage(1);
            Destroy(this);
        }
    }

}
