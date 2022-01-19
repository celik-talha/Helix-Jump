using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Manager managerScript;
    public GameObject platform;
    public GameObject cam;
    float jumpModifier = 1.0f;

    float lastY;
    float thisY;
    float deltaY;
    Vector3 ballRbSpeed;

    Vector3 camPos;
    bool letSlide = false;

    Rigidbody ballRb;
    float startX;
    float deltaX;
    float rotationSpeed = 0.4f;
    string key;
    bool isLive = true;

    void Start()
    {
        ballRb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (isLive)
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
                    else if (deltaX > 360f)
                    {
                        deltaX -= 360f;
                    }
                    platform.transform.rotation= Quaternion.Euler(0f, deltaX, 0f);
                    startX = touch.position.x;
                }
            }
        }
        Debug.Log(ballRb.velocity.y);
    }
    void FixedUpdate()
    {
        if (isLive)
        {
            ballRbSpeed = ballRb.velocity;
            ballRbSpeed.y = Mathf.Clamp(ballRbSpeed.y,-8f,50f);
            ballRb.velocity = ballRbSpeed;
            if (letSlide)
            {
                camSlide();
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Plane"))
        {
            if (isLive)
            {
                camLet(0);
                ballRb.velocity = Vector3.zero;
                ballRb.AddForce(Vector3.up * 250f * jumpModifier);
            }
        }
        else if (collision.transform.CompareTag("Fail"))
        {
            isLive = false;
            ballRb.velocity = Vector3.zero;
            managerScript.levelFailed();
        }
        else if (collision.transform.CompareTag("Pass"))
        {
            isLive = false;
            ballRb.velocity = Vector3.zero;
            managerScript.levelCompleted();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (letSlide == false)
        {
            camLet(1);
        }
    }
    
    void camLet(int x)
    {
        
        if (x == 1)
        {
            letSlide = true;
            lastY = this.transform.position.y;
        }
        else
        {
            letSlide = false;
        }
    }

    void camSlide()
    {
        thisY = this.transform.position.y;
        deltaY = thisY - lastY;
        camPos = cam.transform.position;
        camPos.y = camPos.y + deltaY;
        cam.transform.position = camPos;
        lastY = thisY;
    }
}
