using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0, 1)]
    public float speed;
    public SpriteRenderer Msr;
    public float movemH;
    public float movemV;
    void Start()
    {
        Msr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        movemH = Input.GetAxis("Horizontal");
        movemV =  Input.GetAxis("Vertical");
        transform.position += new Vector3(speed, 0, 0) * Input.GetAxis("Horizontal");        
        transform.position += new Vector3(0, speed, 0) * Input.GetAxis("Vertical");
        
        Msr.flipX = movemH < 0 ? true : false;
        
    }
}

