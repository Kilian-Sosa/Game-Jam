using Unity.Burst.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour {
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float moveDistance = 3f;

    private Vector2 initialPosition;
    private bool direction = true;
    private SpriteRenderer spriteRenderer;

    void Start() {
        initialPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        RaycastHit2D hit = Physics2D.Raycast(
            new Vector2(transform.position.x + 1, transform.position.y), new Vector2(1f, 0), 1f);
        if (direction) {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            if (transform.position.x >= initialPosition.x + moveDistance)
                direction = false;
            spriteRenderer.flipX = false;
        } else {
            hit = Physics2D.Raycast(
            new Vector2(transform.position.x - 1, transform.position.y), new Vector2(-1f, 0), 1f);
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            if (transform.position.x <= initialPosition.x - moveDistance)
                direction = true;

            spriteRenderer.flipX = true;
        }

        if (hit.collider != null) direction = !direction;
    }
}