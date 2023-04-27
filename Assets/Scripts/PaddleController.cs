using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    public bool isRightPaddle;
    public bool isSpeedUp = false;
    private Rigidbody2D rig;
    public PUSizeUpController sizeUp;
    public GameManager gameManager;
    [SerializeField] private float limitUp1;
    [SerializeField] private float limitDown1;
    [SerializeField] private float limitUp2;
    [SerializeField] private float limitDown2;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // move object 
        MoveObject(GetInput());
    }

    public void StartPaddleSpeedUpCoroutine()
    {
        StartCoroutine(PaddleSpeedUp());
    }

    IEnumerator PaddleSpeedUp()
    {
        bool activePaddle = gameManager.rightPaddleActive;

        isSpeedUp = true;

        yield return new WaitForSeconds(5f);

        isSpeedUp = false;

        if (activePaddle)
        {
            gameManager.speedUpChangedKanan = false;
        }
        else if (!activePaddle)
        {
            gameManager.speedUpChangedKiri = false;
        }
    }

    public void StartPaddleChangeCoroutine(float changeTime)
    {
        StartCoroutine(PaddleChange(changeTime));
    }

    IEnumerator PaddleChange(float changeTime)
    {
        // Lerp the size to final position for few seconds
        float t = 0f;
        bool activePaddle = gameManager.rightPaddleActive;
        Vector2 initialHeight = transform.localScale;
        Vector2 finalHeight = new Vector2(transform.localScale.x, transform.localScale.y * 2f);
        while (t < 1f)
        {
            t += Time.deltaTime / changeTime;
            transform.localScale = Vector3.Lerp(initialHeight, finalHeight, t);
            yield return null;
        }

        yield return new WaitForSeconds(5f);

        // Lerp back to normal size
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / changeTime;
            transform.localScale = Vector3.Lerp(finalHeight, initialHeight, t);
            yield return null;
        }

        if (activePaddle)
        {
            gameManager.heightChangedKanan = false;
        }
        else if (!activePaddle)
        {
            gameManager.heightChangedKiri = false;
        }
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            if (isRightPaddle)
            {
                // (no size power up)
                if (!gameManager.heightChangedKanan)
                {
                    // Limit for right paddle down movement so it doesn't collide and bounce with wall (Tembok atas)
                    if (transform.position.y >= limitUp1 && transform.position.y >= limitDown1)
                    {
                        return Vector2.zero;
                    }
                }
                // size power up
                else if (gameManager.heightChangedKanan)
                {
                    // Limit for right paddle down movement so it doesn't collide and bounce with wall (Tembok atas)
                    if (transform.position.y >= limitUp2 && transform.position.y >= limitDown2)
                    {
                        return Vector2.zero;
                    }
                }
            } 
            else if (!isRightPaddle)
            {
                // (no size power up)
                if (!gameManager.heightChangedKiri)
                {
                    // Limit for left paddle down movement so it doesn't collide and bounce with wall (Tembok atas)
                    if (transform.position.y >= limitUp1 && transform.position.y >= limitDown1)
                    {
                        return Vector2.zero;
                    }
                }
                // (size power up)
                else if (gameManager.heightChangedKiri)
                {
                    // Limit for left paddle down movement so it doesn't collide and bounce with wall (Tembok atas)
                    if (transform.position.y >= limitUp2 && transform.position.y >= limitDown2)
                    {
                        return Vector2.zero;
                    }
                }
            }

           return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            if (isRightPaddle)
            {
                // (no size power up)
                if (!gameManager.heightChangedKanan)
                {
                    // Limit for right paddle down movement so it doesn't collide and bounce with wall (Tembok bawah)
                    if (transform.position.y <= limitUp1 && transform.position.y <= limitDown1)
                    {
                        return Vector2.zero;
                    }
                }
                // size power up
                else if (gameManager.heightChangedKanan)
                {
                    // Limit for right paddle down movement so it doesn't collide and bounce with wall (Tembok bawah)
                    if (transform.position.y <= limitUp2 && transform.position.y <= limitDown2)
                    {
                        return Vector2.zero;
                    }
                }
            }
            else if (!isRightPaddle)
            {
                // (no size power up)
                if (!gameManager.heightChangedKiri)
                {
                    // Limit for left paddle down movement so it doesn't collide and bounce with wall (Tembok bawah)
                    if (transform.position.y <= limitUp1 && transform.position.y <= limitDown1)
                    {
                        return Vector2.zero;
                    }
                }
                // (size power up)
                else if (gameManager.heightChangedKiri)
                {
                    // Limit for left paddle down movement so it doesn't collide and bounce with wall (Tembok bawah)
                    if (transform.position.y <= limitUp2 && transform.position.y <= limitDown2)
                    {
                        return Vector2.zero;
                    }
                }
            }

            return Vector2.down * speed;
        }
        else
        {
            return Vector2.zero;
        }
    }
    private void MoveObject(Vector2 movement)
    {
        Debug.Log("TEST: " + movement);
        if (!isSpeedUp)
        {
            rig.velocity = movement;
        }
        else if (isSpeedUp)
        {
            rig.velocity = movement * 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {
            if (isRightPaddle)
            {
                gameManager.rightPaddleActive = true;
            } 
            else if (!isRightPaddle)
            {
                gameManager.rightPaddleActive = false;
            }
        }
    }
}
