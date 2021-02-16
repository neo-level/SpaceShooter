using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // speed of 8.
    [SerializeField] private float speed = 8.0f;   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timeBasedSpeed = speed * Time.deltaTime;
        // translate the laser up.
        transform.Translate(0, timeBasedSpeed, 0);
        
    }
}
