using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class OnlineWallScore : NetworkBehaviour {

    #region private
    [SerializeField]
    private string player = "P1";
    private Text txt_score;

    [SyncVar(hook = "AddScore")]
    private int score = 0;
    #endregion

    private void Start ()
    {
        try
        {
            txt_score = GameObject.Find("Score" + player).GetComponent<Text>();
            txt_score.text = score.ToString();
        }
        catch (NullReferenceException)
        {
            Debug.LogError("[" + this.gameObject.GetInstanceID() + "] " + this.name + " doesn't have a Text component assigned");
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            AddScore();
        }
    }

    private void AddScore(int amount = 0)
    {
        score++;

        try
        {
            txt_score.text = score.ToString();
        }
        catch (NullReferenceException)
        {
            Debug.LogError("[" + this.gameObject.GetInstanceID() + "] " + this.name + " doesn't have a Text component assigned");
        }
    }
}
