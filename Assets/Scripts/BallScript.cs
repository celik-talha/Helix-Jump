using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject platform;

    Rigidbody ballRb;
    float startX;
    float deltaX;
    float rotationSpeed = 0.4f;
    string key;

    void Start()
    {
        ballRb = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.touchCount != 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startX = touch.position.x;
            }
            else if (touch.phase== TouchPhase.Moved)
            {
                deltaX += (-(touch.position.x - startX) * rotationSpeed);
                if (deltaX < -360f)
                {
                    deltaX += 360f;
                }
                platform.transform.rotation= Quaternion.Euler(0f, deltaX, 0f);
                startX = touch.position.x;
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        ballRb.AddForce(Vector3.up * 250f);
        Debug.Log(collision.transform.name);

    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
