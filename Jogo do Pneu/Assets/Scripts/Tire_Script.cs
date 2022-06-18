using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire_Script : MonoBehaviour
{
    //Private Variables
    Rigidbody rb;
    bool grounded = false;
    //Public Variables
    public bool player = false;
    public bool showcase = false;
    [Space]
    float minVelocity;
    float forwardForce;
    float downwardForce;
    [Space]
    public TrailRenderer trail;

    #region AI Config Variables
    float reactionTime;
    float flyTime;
    float pointsTime;
    #endregion

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        trail = transform.GetChild(transform.childCount - 1).gameObject.GetComponent<TrailRenderer>();

        #region AI Config Settings
        reactionTime = Random.Range(0f, .6f);
        flyTime = Random.Range(0f, 1f);
        pointsTime = .3f;
        #endregion

        minVelocity = 5;
        forwardForce = 25;
        downwardForce = 25;
    }

    void FixedUpdate()
    {
        if(!GameManager.manager.gamePaused)
        {
            if (rb.velocity.z < minVelocity)
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, minVelocity);
            rb.AddForce(Vector3.forward * 5);

            if(!showcase)
            {
                if (player)
                    PlayerControls();
                else
                    AIControls();
            }
            else
            {
                trail.emitting = true;
            }
            
        }
    }

    void PlayerControls()
    {
        if (grounded)
        {
            if (AcceleratePedal.pisaFundo && rb.velocity.y < 0)
            {
                rb.AddForce(Vector3.forward * forwardForce);
                trail.emitting = true;
            }
            else if (Input.GetKey(KeyCode.K) && rb.velocity.y >= 0)
            {
                rb.AddForce(Vector3.back * (forwardForce / 2));
                trail.emitting = false;
            }
            else
            {
                trail.emitting = false;
            }

            pointsTime = .3f;
        }
        else
        {
            if (AcceleratePedal.pisaFundo)
            {
                rb.AddForce(Vector3.down * downwardForce);
                trail.emitting = true;
            }
            else
            {
                trail.emitting = false;
            }

            pointsTime -= Time.deltaTime;
            if(pointsTime <= 0)
            {
                Points.AddPoints();
            }
        }
    }

    void AIControls()
    {
        if(grounded)
        {
            if (rb.velocity.y < 0)
            {
                reactionTime -= Time.deltaTime;
                if (reactionTime <= 0)
                {
                    rb.AddForce(Vector3.forward * forwardForce);
                    trail.emitting = true;
                }
                else
                {
                    trail.emitting = false;
                }
            }
            else
            {
                trail.emitting = false;
            }

            flyTime = Random.Range(0f, 1f);
        }
        else
        {
            flyTime -= Time.deltaTime;
            if(flyTime <= 0)
            {
                rb.AddForce(Vector3.down * downwardForce);
                trail.emitting = true;
            }
            else
            {
                trail.emitting = false;
            }

            reactionTime = Random.Range(0f, .6f);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
