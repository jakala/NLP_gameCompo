using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour {
    GameObject  temp, player;
    PlayerController playerController;
    Text coin;
    int points;
    private void Start()
    {
        player = GameManager.instance.player;
        playerController = player.GetComponent<PlayerController>();
        temp = GameObject.FindGameObjectWithTag("coin");
        coin = temp.GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player")) {
            points = int.Parse(coin.text) + 1;
            playerController.Points(points);
            coin.text = (int.Parse(coin.text) + 1 )+ ""; 
            Destroy(gameObject);
        }
    }
}
