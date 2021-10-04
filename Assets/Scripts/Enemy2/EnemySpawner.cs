using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public BarnHealth stable;
    public BoolSO failure;
    public BoolSO victory;
    private float stableMaxHealth;

    public Transform AnimalSpawnPoint;
    public Transform PitchforkSpawnPoint;
    public Transform ChickenSpawnPoint;

    public List<GameObject> EnemiesGreen;
    public List<GameObject> EnemiesYellow;
    public List<GameObject> EnemiesRed;

    public float spawnIntervalG = 2f;
    public float spawnIntervalY = 1f;
    public float spawnIntervalR = 1.5f;

    private float timeOfNextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeOfNextSpawn = Time.time + spawnIntervalG;
        stableMaxHealth = stable.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (failure.active || victory.active) return;
        if (Time.time > timeOfNextSpawn)
        {
            float stableHealthPercent = stable.health / stableMaxHealth;
            // Spawn enemy based on phase
            if (stableHealthPercent > 0.7f)
            {
                SpawnEnemy(1, EnemiesGreen);
                timeOfNextSpawn = Time.time + spawnIntervalG;
            }
            else if (stableHealthPercent < 0.7f && stableHealthPercent > 0.3f)
            {
                SpawnEnemy(1, EnemiesYellow);
                timeOfNextSpawn = Time.time + spawnIntervalY;
            }
            else
            {
                SpawnEnemy(2, EnemiesRed);
                timeOfNextSpawn = Time.time + spawnIntervalR;
            }
            
        }
       
    }

    // Picks one enemy at random from the list to spawn
    private void SpawnEnemy(int count, List<GameObject> enemies)
    {
        HashSet<int> chosen = new HashSet<int>();
        for (int i = 0; i < count; i++)
        {
            int idx = Random.Range(0, enemies.Count);
            while (chosen.Contains(idx))
            {
                idx = Random.Range(0, enemies.Count);
            }
            chosen.Add(idx);

            Vector3 spawnPosition;
            if (enemies[idx].tag == "Pitchfork")
            {
                spawnPosition = PitchforkSpawnPoint.position;
            }
            else if (enemies[idx].tag == "Chicken")
            {
                spawnPosition = ChickenSpawnPoint.position;
            }
            else
            {
                spawnPosition = AnimalSpawnPoint.position;
            }

            Instantiate(enemies[idx], spawnPosition, AnimalSpawnPoint.rotation, transform);
        }
    }
}
