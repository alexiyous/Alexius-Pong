using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;

    public Rigidbody2D rig;

    public Vector2 resetPosition;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void MoveLeftOnReset()
    {
        rig.velocity = -speed;
    }

    public void MoveRightOnReset()
    {
        rig.velocity = speed;
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        StartCoroutine(BallSpeedUp(magnitude));
    }

    IEnumerator BallSpeedUp(float magnitude)
    {
        // change the speed
        rig.velocity *= magnitude;

        // wait for 3 second
        yield return new WaitForSeconds(3f);

        if (rig.velocity.x > speed.x)
        {
            // change to normal speed
            rig.velocity *= 0.5f;
        }
    }
}
