using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Level1EnemyClass;
    [SerializeField] private GameObject Level2EnemyClass;
    [SerializeField] private GameObject Level3EnemyClass;

    private void Start()
    {
        GameObject EnemyToSpawn = SelectEnemy();
        if(EnemyToSpawn != null)
        {
            Instantiate(SelectEnemy(), transform.position, transform.rotation);
        }
        Destroy(gameObject, 0.5f);
    }

    private GameObject SelectEnemy()
    {
        return GameMode.Instance.getPlayerLevel() switch
        {
            0 => Level1EnemyClass,
            1 => Level2EnemyClass,
            2 => Level3EnemyClass,
            _ => Level3EnemyClass,
        };
    }
}
