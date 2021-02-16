using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;

    [SerializeField] private float speed = 3.5f;
    [SerializeField] private float fireRate = 0.15f;
    [SerializeField] private sbyte lives = 3;

    private float _topBoundary = 0.0f;
    private float _rightBoundary = 11.3f;
    private float _bottomBoundary = -3.8f;
    private float _leftBoundary = -11.3f;
    private float _offset = 0.8f;
    private float _canFire = -1.0f;

    private void Start()
    {
        // take the current position = new position(0,0,0).
        transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(key: KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    private void CalculateMovement()
    {
        // Move player.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * (speed * Time.deltaTime));


        // Prevents the user from passing the top and bottom boundaries. "clamping" between two values.
        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y, _bottomBoundary, _topBoundary), 0);

        // wraps the right and left boundaries, when the player reaches the edge, warp to the other side.
        if (transform.position.x >= _rightBoundary)
        {
            transform.position = new Vector3(_leftBoundary, transform.position.y, 0);
        }
        else if (transform.position.x <= _leftBoundary)
        {
            transform.position = new Vector3(_rightBoundary, transform.position.y, 0);
        }
    }

    private void FireLaser()
    {
        _canFire = Time.time + fireRate;

        Vector3 spawnLocation =
            new Vector3(transform.position.x, transform.position.y + _offset, transform.position.z);

        Instantiate(laserPrefab, spawnLocation, Quaternion.identity);
    }
    
    public void Damage()
    {
        lives--;

        if (lives < 1)
        {
            Destroy(gameObject);
        }
    }
}