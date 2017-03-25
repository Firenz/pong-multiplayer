using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour {

    #region public
    public AudioClip bouncingWallSound;
    public AudioClip bouncingPaddleSound;
    #endregion

    #region private
    [SerializeField]
    private float speed = 8f;

    private Transform thisTransform;
    private Rigidbody thisRigidbody;
    #endregion

    private void Start () {
        thisTransform = this.transform;
        thisRigidbody = thisTransform.GetComponent<Rigidbody>();

        thisRigidbody.velocity = Vector3.right * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "P1" || collision.gameObject.tag == "P2")
        {
            ChangeDirection(collision);
            AudioSource.PlayClipAtPoint(bouncingPaddleSound, thisTransform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(bouncingWallSound, thisTransform.position);
        }
    }

    private void ChangeDirection(Collision collision)
    {
        float newDirectionY = HitFactor(thisTransform.position, collision.transform.position, collision.collider.bounds.size.y);
        float newDirectionX = (thisRigidbody.velocity.x >= 0f) ? 1f: -1f;

        Vector3 direction = new Vector3(newDirectionX, newDirectionY, 0f).normalized;
        thisRigidbody.velocity = direction * speed;
    }

    private float HitFactor(Vector3 ballPosition, Vector3 paddlePosition, float paddleHeight)
    {
        return (ballPosition.y - paddlePosition.y) / paddleHeight;
    }
}
