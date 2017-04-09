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

    [SyncVar(hook = "OnScoreChanged")]
    private int score = 0;
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            CmdAddScore();
        }
    }

    [Command]
    private void CmdAddScore()
    {
        score++;
    }

    private void OnScoreChanged(int newScore)
    {
        try
        {
            txt_score.text = newScore.ToString();
        }
        catch (NullReferenceException)
        {
            Debug.LogError("[" + this.gameObject.GetInstanceID() + "] " + this.name + " doesn't have a Text component assigned");
        }
    }

    public override void OnStartClient()
    {
        txt_score = GameObject.Find("Score" + player).GetComponent<Text>();
        OnScoreChanged(score);
    }
}
