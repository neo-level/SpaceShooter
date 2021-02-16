using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    private float _bottomBoundary = -5.5f;
    private float _rightBoundary = 9.5f;
    private float _leftBoundary = -9.5f;
    private float _spawnPoint = 6.5f;


    private void Update()
    {
        // Get random value for the x position.
        float randomXvalue = Random.Range(_leftBoundary, _rightBoundary);

        float timeBasedSpeed = speed * Time.deltaTime;

        // Move the enemy downwards.
        transform.Translate(Vector3.down * timeBasedSpeed);

        // If the enemy reaches the bottom, warp to a random spawn position on the top.
        if (transform.position.y <= _bottomBoundary)
        {
            transform.position = new Vector3(randomXvalue, _spawnPoint, 0);
        }
    }
}