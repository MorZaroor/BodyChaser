using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParameter : MonoBehaviour
{
    public float tiltAngle = 45f; // �ő�X����p�x
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
