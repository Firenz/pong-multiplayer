using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleInputHandler : MonoBehaviour {

    #region private
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private string axis = "Vertical";

    private Rigidbody thisRigidbody;
    #endregion

    private void Start()
    {
        thisRigidbody = this.transform.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float currentVelocity = Input.GetAxisRaw(axis);
        thisRigidbody.velocity = Vector3.up * speed * currentVelocity;
    }
}
