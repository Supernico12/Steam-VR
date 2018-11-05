using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    LevelManager level;
    [SerializeField]
    float health;


    public float currenthealth;
    [SerializeField] GameObject ammoDrop;




    public event System.Action OnTakeDamage;




    public void TakeDamage(float damage)
    {
        if (currenthealth - damage < health)
        {
            currenthealth -= damage;
        }

        if (currenthealth <= 0)
        {
            Die();
        }
        if (damage > 0)
        {
            if (OnTakeDamage != null)
                OnTakeDamage.Invoke();
        }
    }


    public virtual void Die()
    {

        Destroy(gameObject);
    }

    void Start()
    {

        currenthealth = health;

    }

    public float GetHealth
    {
        get
        {
            return currenthealth;

        }
    }
    public float GetMaxHealth
    {


        get
        {
            return health;

        }

    }
}
