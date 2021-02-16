using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;

    private sbyte _spawnInterval = 5;

    private bool _stopSpawning;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    
    /// <summary>
    /// Spawns an enemy on a given interval on a random location.
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnRoutine()
    {
        while (!_stopSpawning)
        {
            Vector3 spawnPosition = enemyPrefab.GetComponent<Enemy>().GenerateRandomPosition();

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            // Move the enemy to the container.
            newEnemy.transform.parent = enemyContainer.transform;
            
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
    
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}