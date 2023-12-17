using UnityEngine;

public class Enemy1Controller : MonoBehaviour {
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float moveDistance = 2f;

    private Vector2 leftPosition;
    private Vector2 rightPosition;
    private bool MoveTowardsRight = true;
    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CalculateLeftPosition();
        CalculateRightPosition();
        Flip();
    }

    private void CalculateLeftPosition()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.left, moveDistance + 1);
        foreach (RaycastHit2D hit in hits ) { 
            if (hit.collider.CompareTag("Ground"))
            {
                leftPosition = hit.point;
                return;
            }
        }
        leftPosition = transform.position + new Vector3(transform.position.x - moveDistance, 0, 0);
    }

    private void CalculateRightPosition()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.right, moveDistance);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Ground"))
            {
                rightPosition = hit.point;
                return;
            }
        }
        rightPosition = transform.position + new Vector3(transform.position.x + moveDistance, 0, 0);
    }

    void Update() {
        Vector2 endposition = MoveTowardsRight ? rightPosition : leftPosition;
        float direction = endposition.x < transform.position.x ? transform.position.x + -moveSpeed * Time.deltaTime : transform.position.x + moveSpeed * Time.deltaTime;

        transform.position = new Vector2(direction, transform.position.y);
        if (Vector2.Distance(transform.position, endposition) < 1f) {
            Flip();
        }
    }

    private void Flip()
    {
        MoveTowardsRight = !MoveTowardsRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) GameMode.Instance.PlayerDeath();
    }
}