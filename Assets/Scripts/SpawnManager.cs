using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private sbyte _spawnInterval = 5;

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
        while (true)
        {
            Vector3 spawnPosition = enemyPrefab.GetComponent<Enemy>().GenerateRandomPosition();

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}