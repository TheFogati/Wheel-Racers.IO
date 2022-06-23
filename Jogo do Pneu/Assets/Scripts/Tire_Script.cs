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
    public TrailRenderer trailT;
    public ParticleSystem[] trailP;

    #region AI Config Variables
    float reactionTime;
    float flyTime;
    #endregion


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        trailT = transform.GetChild(transform.childCount - 1).gameObject.GetComponent<TrailRenderer>();
        trailP = transform.GetChild(transform.childCount - 1).transform.GetComponentsInChildren<ParticleSystem>();

        #region AI Config Settings
        reactionTime = Random.Range(0f, .6f);
        flyTime = Random.Range(0f, 1f);
        #endregion

        minVelocity = 5;
        forwardForce = 25;
        downwardForce = 25;

        if(!showcase)
            rb.velocity = Vector3.forward * 15;
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
                if (trailT != null)
                trailT.emitting = true;
                if (trailP != null)
                    ParticlesOn();
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

                if (trailT != null)
                    trailT.emitting = true;
                if (trailP != null)
                    ParticlesOn();
            }
            else if (Input.GetKey(KeyCode.K) && rb.velocity.y >= 0)
            {
                rb.AddForce(Vector3.back * (forwardForce / 2));

                if (trailT != null)
                    trailT.emitting = false;
                if (trailP != null)
                    ParticlesOff();
            }
            else
            {
                if (trailT != null)
                    trailT.emitting = false;
                if (trailP != null)
                    ParticlesOff();
            }
        }
        else
        {
            if (AcceleratePedal.pisaFundo)
            {
                rb.AddForce(Vector3.down * downwardForce);

                if (trailT != null)
                    trailT.emitting = true;
                if (trailP != null)
                    ParticlesOn();
            }
            else
            {
                if (trailT != null)
                    trailT.emitting = false;
                if (trailP != null)
                    ParticlesOff();
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

                    if (trailT != null)
                        trailT.emitting = true;
                    if (trailP != null)
                        ParticlesOn();
                }
                else
                {
                    if (trailT != null)
                        trailT.emitting = false;
                    if (trailP != null)
                        ParticlesOff();
                }
            }
            else
            {
                if (trailT != null)
                    trailT.emitting = false;
                if (trailP != null)
                    ParticlesOff();
            }

            flyTime = Random.Range(0f, 1f);
        }
        else
        {
            flyTime -= Time.deltaTime;
            if(flyTime <= 0)
            {
                rb.AddForce(Vector3.down * downwardForce);

                if (trailT != null)
                    trailT.emitting = true;
                if (trailP != null)
                    ParticlesOn();
            }
            else
            {
                if (trailT != null)
                    trailT.emitting = false;
                if (trailP != null)
                    ParticlesOff();
            }

            reactionTime = Random.Range(0f, .6f);
        }
    }

    void ParticlesOn()
    {
        foreach(ParticleSystem ps in trailP)
        {
            ps.Play();
        }
    }
    void ParticlesOff()
    {
        foreach (ParticleSystem ps in trailP)
        {
            ps.Stop();
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
