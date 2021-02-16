using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 8.0f;
    private float _topBoundary = 8.0f;

    private void Update()
    {
        CalculateMovement();
    }

    /// <summary>
    /// Moves the object in an upward direction.
    /// </summary>
    private void CalculateMovement()
    {
        float timeBasedSpeed = speed * Time.deltaTime;
        float myCurrentVerticalPosition = transform.position.y;

        // Moves the projectile forward.
        transform.Translate(Vector3.up * timeBasedSpeed);

        DestroyWhenOutOfBounds(myCurrentVerticalPosition);
    }

    /// <summary>
    /// Destroy the projectile once the Y threshold has been met.
    /// </summary>
    /// <param name="currentPosition"></param>
    private void DestroyWhenOutOfBounds(float currentPosition)
    {
        if (currentPosition >= _topBoundary)
        {
            Destroy(gameObject);
        }
    }
}