using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OnlineGameSpawner : NetworkBehaviour {

    public GameObject ballPrefab;
    public GameObject leftWallPrefab;
    public GameObject rightWallPrefab;

    public override void OnStartServer()
    {
        GameObject ball = Instantiate<GameObject>(ballPrefab, new Vector3(0f, 0f, -9f), Quaternion.identity);
        GameObject leftWall = Instantiate<GameObject>(leftWallPrefab, new Vector3(9.38f, 0f, -9f), Quaternion.identity);
        GameObject rightWall = Instantiate<GameObject>(rightWallPrefab, new Vector3(-9.38f, 0f, -9f), Quaternion.identity);

        NetworkServer.Spawn(ball);
        NetworkServer.Spawn(leftWall);
        NetworkServer.Spawn(rightWall);
    }
}
