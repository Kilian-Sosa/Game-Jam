using UnityEngine;

public class ParallaxMotion : MonoBehaviour {

    [SerializeField] float parallaxSpeed;

    void Update() {
        if (Input.GetAxisRaw("Horizontal") == 1)
            GetComponent<SpriteRenderer>().material.mainTextureOffset += Vector2.right * parallaxSpeed * Time.deltaTime;
    }
}