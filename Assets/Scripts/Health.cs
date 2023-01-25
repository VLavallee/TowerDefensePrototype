using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform vFXPosition;

    public void DealDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }
    private void TriggerDeathVFX()
    {
        if(!deathVFX) { return; }

        var deathFX = Instantiate(deathVFX, vFXPosition.position, Quaternion.identity);
        Destroy(deathFX, 2f);
    }

    
}
