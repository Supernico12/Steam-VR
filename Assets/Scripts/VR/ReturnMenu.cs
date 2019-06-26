using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnMenu : MonoBehaviour
{
    public Transform Player;
    public Transform spawnPos;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Start()
    {
        Player = dointDestroy.playerInstance.GetComponent<Transform>();
        Player.position = spawnPos.position;
        dointDestroy.playerInstance.GetComponentInChildren<StickManipulation>().defaultposY = spawnPos.position.y;
    }
}
