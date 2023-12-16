using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour {
    [SerializeField] float bulletSpeed = 20f;

    void Start() {
        Vector2 difference = GameObject.Find("Player").transform.position - transform.position;
        GetComponent<Rigidbody2D>().velocity = difference.normalized * bulletSpeed;
        Destroy(gameObject, 1.5f);
    }

    void Update() {
        if (transform.position.x < GameObject.Find("Player").GetComponent<Transform>().position.x) {
            //hud.score++;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Collides with " + collision.gameObject.tag);
            //GameObject.Find("SoundManager").GetComponent<soundManager>().PlayAudio("collision");
            //SceneManager.LoadScene("Lose", LoadSceneMode.Single);
        }
    }
}