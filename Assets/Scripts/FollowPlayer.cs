using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    GameObject player;
    float offsetX, offsetY;
    Camera cam;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        cam = GetComponent<Camera>();
    }

    // Use this for initialization
    void Start ()
    {
        offsetX = transform.position.x - player.transform.position.x;
        offsetY = transform.position.y - player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 newPosition = new Vector3(playerPosition.x + offsetX, playerPosition.y + offsetY, transform.position.z);
        transform.position = newPosition;
	}
}
