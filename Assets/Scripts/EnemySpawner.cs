using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnFrequency = 2;
    [SerializeField] private float spawnDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(createEnemy), spawnDelay, spawnFrequency);
    }

    private void createEnemy()
    {
        var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<Enemy>().setWaypoints(waypoints);
    }
}
