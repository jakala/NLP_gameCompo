using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject panelWin, panelDie;
    private int live = 3;
    private Animator anim;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private bool OnFloor;
    [SerializeField] private float move_h;
    [SerializeField] private Transform floorTransform;
    public float acceleration,
        jumpForce ,
        maxSpeed = 2.0f,
        x,
        y,
        maxFloorDistance = 1.0f;
    private int totalCoins;

	// Use this for initialization
	void Start () {
        totalCoins = GameObject.FindGameObjectsWithTag("money").Length;
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    private void Update () {
        float h = Input.GetAxis("Horizontal");
        OnFloor = InFloor();

        Turn(h);
        float speed = maxSpeed * h * Time.deltaTime;
        rb.position = new Vector2(rb.position.x + speed, rb.position.y);

        anim.SetFloat("velocity", Mathf.Abs(h));
        if (Input.GetKeyDown(KeyCode.Space) && OnFloor)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Turn(float h)
    {
        if (h != 0) {
            sr.flipX = (h < 0);
        }
    }

    private bool InFloor() {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit);
        return (hit.distance < 0.1f);
    }

    public void Damage(int value) {
        live = Mathf.Clamp(live - value, 0, 3);
        if (live <= 0) {
            panelDie.SetActive(true);
        }
    }

    public void Points(int totalPoints) {
        if (totalPoints == totalCoins) {
            panelWin.SetActive(true);
        }
    }

}
