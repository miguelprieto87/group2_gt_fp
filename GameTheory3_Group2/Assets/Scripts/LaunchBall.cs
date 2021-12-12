using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LaunchBall : MonoBehaviour
{
    public Image powerMeter;
    public Image angleMeter;
    public Rigidbody2D myRb;
    Quaternion angle;
    public float pingPongAmount;
    float pingPongLevel;
    float launchMultiplier;
    public float maxForce;
    float launchForce;
    public float maxAngle;
    float launchAngle;
    float time = 0f;
    public bool forceSet;
    public bool angleSet;
    public bool launched;


    
    // Update is called once per frame
    void Update()
    {
        SetLaunchAngle();
        SetLaunchForce();
        LaunchTheObject();
    }

    public void LaunchTheObject()
    {
        if (Input.GetButtonDown("Space") && forceSet && angleSet && !launched)
        {
            myRb.AddForce(angle * transform.right * launchForce, ForceMode2D.Impulse);
            AudioManager.instance.playCanonFire();
            launched = true;
            Debug.Log("Space pressed");
        }
        
    }

    public void SetLaunchForce()
    {
        if (!forceSet && angleSet) 
        {
            time += Time.deltaTime;
            pingPongLevel = Mathf.PingPong(time, pingPongAmount);
            launchMultiplier = pingPongLevel / pingPongAmount;
            powerMeter.fillAmount = launchMultiplier;
            if (Input.GetButtonDown("Space"))
            {
                launchForce = maxForce * launchMultiplier;
                forceSet = true;                
            }
        }
    }

    public void SetLaunchAngle()
    {
        if (!angleSet)
        {
            time += Time.deltaTime;
            launchAngle = Mathf.PingPong(time * 50, maxAngle);
            angleMeter.fillAmount = launchAngle / maxAngle;
            if (Input.GetButtonDown("Space"))
            {
                angle = Quaternion.AngleAxis(launchAngle, transform.forward);
                StartCoroutine(Wait1SecondForAngle());
            }
            
        }
    }

    IEnumerator Wait1SecondForAngle()
    {
        //Debug.Log("Coroutine Started");
        yield return new WaitForSeconds(0.01f);
        angleSet = true;
        time = 0;
        //Debug.Log("Coroutine Ended");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            AudioManager.instance.playHitGround();
        }
    }
}
