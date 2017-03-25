using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour {

    #region private
    [SerializeField]
    private int sceneID = 0;
    #endregion

    public void OnClick()
    {
        SceneManager.LoadScene(sceneID, LoadSceneMode.Single);
    }

}
