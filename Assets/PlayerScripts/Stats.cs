using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public XStats playerStats;
    private float jumpForce;
    private float speed;
   
    private void Start()
    {
        jumpForce = playerStats.jumpForce;
        speed = playerStats.speed;
    }

    public float getJumpForce()
    {
        return jumpForce;
    }

    public float getSpeed()
    {
        return speed;
    }

    public void AddSpeed(float amount)
    {
        speed += amount;
    }

    public void AddSpeed(float amount, float maxAmount)
    {
        if(speed < maxAmount)
        {
            AddSpeed(amount);
        }
    }
    
}
