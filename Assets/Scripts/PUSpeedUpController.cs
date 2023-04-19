using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public Collider2D ball;
    public float magnitude;
    public PowerUpManager manager;
    public ParticleSystem powerUpEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            // Speed Up the ball 
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
            Instantiate(powerUpEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            manager.RemovePowerUp(gameObject);
        }
    }

}
