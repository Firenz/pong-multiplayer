using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallScore : MonoBehaviour {

    #region public
    public Text txt_score;
    #endregion

    #region private
    private int score = 0;
    #endregion

    private void Start ()
    {
        try
        {
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

    private void AddScore()
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
