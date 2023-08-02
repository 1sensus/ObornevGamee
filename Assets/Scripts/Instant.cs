using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instant : MonoBehaviour
{

    public float TStart=10f;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-40, 40), Random.Range(-28, 28), 0.0f);
    }

    void Update()
    {
        if (true)
        { 
            TStart-=Time.deltaTime;
            
        }
        if (TStart < 0)
        {
            TStart = 10f;
            transform.position = new Vector3(Random.Range(-40, 40), Random.Range(-28, 28), 0.0f);
        }

    }

    
}
