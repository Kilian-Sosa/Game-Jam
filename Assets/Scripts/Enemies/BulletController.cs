using UnityEngine;

public class BulletController : MonoBehaviour {
    [SerializeField] float bulletSpeed = 1f;

    void Start() {
        Vector2 difference = GameObject.Find("Player").transform.position - transform.position;
        GetComponent<Rigidbody2D>().velocity = difference.normalized * bulletSpeed;
        Destroy(gameObject, 2.5f);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Bullet");
            GameMode.Instance.PlayerDeath();
            //GameObject.Find("SoundManager").GetComponent<soundManager>().PlayAudio("collision");
            Destroy(gameObject);
        } else if(collision.CompareTag("Ground")) Destroy(gameObject);
    }
}