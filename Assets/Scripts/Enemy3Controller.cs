using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] GameObject bulletEnemyPrefab;
    private GameObject bullet = null;

    void Update() {
        Vector2 difference = GameObject.Find("Player").transform.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(
            new Vector2(transform.position.x - 2, transform.position.y), difference.normalized, 10f);

        Debug.DrawRay(new Vector2(transform.position.x - 1,
            transform.position.y), difference.normalized * 10f, Color.red);

        if (hit.collider != null && hit.collider.name == "Player") Shoot();        
    }

    private void Shoot() {
        if (bullet != null) return;

        bullet = Instantiate(bulletEnemyPrefab, transform.position, Quaternion.identity);
        //GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayAudio("enemyShot");
        new WaitForSeconds(2.5f);
    }
}
