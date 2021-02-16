using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float speed = 4.0f;

    private float _bottomBoundary = -5.5f;
    private float _rightBoundary = 9.5f;
    private float _leftBoundary = -9.5f;
    private float _spawnPoint = 6.5f;

    private void Start()
    {
        // var startPosition = GenerateRandomPosition();
        // Instantiate(enemy, startPosition, Quaternion.identity);
    }

    private void Update()
    {
        float timeBasedSpeed = speed * Time.deltaTime;

        // Move the enemy downwards.
        transform.Translate(Vector3.down * timeBasedSpeed);

        // If the enemy reaches the bottom, warp to a random spawn position on the top.
        if (transform.position.y <= _bottomBoundary)
        {
            transform.position = GenerateRandomPosition();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        /*
         * if other is player, damage player then destroy us
         * if other is laser, destroy us
         */

        switch (other.tag)
        {
            case "Player":
                // Damage the player.
                Player player = other.transform.GetComponent<Player>();
                
                if (player != null)
                {
                    player.Damage();
                }

                Destroy(gameObject);
                break;
            case "Laser":
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        float randomXvalue = Random.Range(_leftBoundary, _rightBoundary);

        Vector3 randomLocation = new Vector3(randomXvalue, _spawnPoint, 0);

        return randomLocation;
    }
}