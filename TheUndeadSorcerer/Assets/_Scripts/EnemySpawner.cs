using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int minNumEnemies;
    public int maxNumEnemies;
    public int randomNumEnemies;
    public float spawnRadius;
    public float maxHeight;

    private void Awake()
    {
        randomNumEnemies = Random.Range(minNumEnemies, maxNumEnemies);
    }

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < randomNumEnemies; i++)
        {
            Vector3 randomPosition = RandomNavMeshPosition(spawnRadius);

            GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
            agent.SetDestination(randomPosition);
        }
    }

    private Vector3 RandomNavMeshPosition(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        randomDirection.y = maxHeight;

        RaycastHit hit;
        if (Physics.Raycast(randomDirection, Vector3.down, out hit))
        {
            if (hit.point.y <= maxHeight)
            {
                return hit.point;
            }
        }

        return RandomNavMeshPosition(radius);
    }
}
