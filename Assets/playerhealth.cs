using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerhealth : CharacterStats
{

    public override void Die()
    {
        currenthealth = GetMaxHealth;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(0);

    }
}
