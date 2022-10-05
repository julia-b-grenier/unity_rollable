using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float amplitude;

    private float posYinit;

    void Start()
    {
        posYinit = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (amplitude == 0)
            amplitude = 1;
         // Set the y position to loop much faster between -3 and 3
        transform.position = new Vector3(transform.position.x, posYinit+Mathf.Sin(Time.time*2) * amplitude, transform.position.z);
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime); // deltaTime is a float representing the difference in seconds since the last frame occured
    }
}
