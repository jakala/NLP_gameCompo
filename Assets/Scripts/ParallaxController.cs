using UnityEngine;
using UnityEngine.UI;

public class ParallaxController : MonoBehaviour {
    public float parallaxSpeed = 0.02f;
    public RawImage stars;
    float speed;

    // Update is called once per frame
    void FixedUpdate () {
            float h = Input.GetAxis("Horizontal");
            speed = parallaxSpeed * h * Time.deltaTime;
            stars.uvRect = new Rect(stars.uvRect.x + speed, 0f, 1.0f, 1.0f);
    }


}
