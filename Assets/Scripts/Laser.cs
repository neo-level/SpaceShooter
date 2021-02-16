using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // speed of 8.
    [SerializeField] private float speed = 8.0f;
    private float _topBoundary = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame    
    void Update()
    {
        float timeBasedSpeed = speed * Time.deltaTime;
        float myCurrentVerticalPosition = transform.position.y;
        
        // Moves the projectile forward.
        transform.Translate(Vector3.up * timeBasedSpeed);

        if (myCurrentVerticalPosition >= _topBoundary)
        {
            Destroy(gameObject);
        }
        
    }
}
