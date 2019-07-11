using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Singelton

    public static PlayerManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Trying To Instance 2 Player Managers");
            return;
        }
        instance = this;


    }

    #endregion

    void Start()
    {
        if (playertransform == null)
            playertransform = dointDestroy.playerInstance.playerTransform;
        if (player == null)
            player = dointDestroy.playerInstance.gameObject;
    }

    public GameObject player;
    public Transform playertransform;


}
