using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSizeUpController : MonoBehaviour
{
    public Collider2D ball;
    public PowerUpManager powerUpManager;
    public ParticleSystem powerUpEffect;
    public PaddleController paddleKanan;
    public PaddleController paddleKiri;
    public GameManager gameManager;
    public float changeTime = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            Instantiate(powerUpEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            powerUpManager.RemovePowerUp(gameObject);
            if (gameManager.rightPaddleActive)
            {
                if (!gameManager.heightChangedKanan)
                {
                    gameManager.heightChangedKanan = true;
                    paddleKanan.StartPaddleChangeCoroutine(changeTime);
                }
            } 
            else if (!gameManager.rightPaddleActive)
            {
                if (!gameManager.heightChangedKiri)
                {
                    gameManager.heightChangedKiri = true;
                    paddleKiri.StartPaddleChangeCoroutine(changeTime);
                }
            }
        }
    }
}
