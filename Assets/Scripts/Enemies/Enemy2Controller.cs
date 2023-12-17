using UnityEngine;

public class Enemy2Controller : MonoBehaviour {
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float moveDistance = 3f;

    private Vector2 initialPosition;
    private bool direction = true;

    void Start() {
        initialPosition = transform.position;
    }

    void Update() {
        RaycastHit2D hit = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y + 1), new Vector2(0, 1f), 1f);
        if (direction) {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

            if (transform.position.y >= initialPosition.y + moveDistance)
                direction = false;
        } else {
            hit = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - 1), new Vector2(0, -1f), 1f);
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

            if (transform.position.y <= initialPosition.y - moveDistance)
                direction = true;
        }

        if (hit.collider != null && !hit.collider.CompareTag("Player")) direction = !direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) GameMode.Instance.PlayerDeath();
    }
}