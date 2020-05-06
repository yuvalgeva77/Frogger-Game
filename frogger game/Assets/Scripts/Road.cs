using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)

    {
        if (col.tag == "car")
        {
            Destroy(col.gameObject);
        }


    }
    void OnCollisionEnter2D(Collision2D other)

    {
        Debug.Log("Player collided hit");

    }
}