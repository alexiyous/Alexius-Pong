using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpPaddleController : MonoBehaviour
{
    public Collider2D ball;
    public PowerUpManager powerUpManager;
    public ParticleSystem powerUpEffect;
    public PaddleController paddleKanan;
    public PaddleController paddleKiri;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            Instantiate(powerUpEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            powerUpManager.RemovePowerUp(gameObject);
            if (gameManager.rightPaddleActive)
            {
                if (!gameManager.speedUpChangedKanan)
                {
                    gameManager.speedUpChangedKanan = true;
                    paddleKanan.StartPaddleSpeedUpCoroutine();
                }
            }
            else if (!gameManager.rightPaddleActive)
            {
                if (!gameManager.speedUpChangedKiri)
                {
                    gameManager.speedUpChangedKiri = true;
                    paddleKiri.StartPaddleSpeedUpCoroutine();
                }
            }
        }
    }
}
