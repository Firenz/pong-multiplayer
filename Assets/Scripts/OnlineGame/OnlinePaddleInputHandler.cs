using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]
public class OnlinePaddleInputHandler : NetworkBehaviour
{

    #region private
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private string axis = "Vertical";

    private Rigidbody thisRigidbody;
    #endregion

    private void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        thisRigidbody = this.transform.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float currentVelocity = Input.GetAxisRaw("Vertical");
        thisRigidbody.velocity = Vector3.up * speed * currentVelocity;
    }

    public override void OnStartLocalPlayer()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
