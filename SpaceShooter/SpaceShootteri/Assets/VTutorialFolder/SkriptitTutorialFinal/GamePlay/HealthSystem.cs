using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private string tagName;
    public bool isEnemy = true;
    public GameObject hitEffect, healthBar;
    public float maxHealth = 10f;
    public float currentHealth;


    // Start is called before the first frame update
    void OnEnable()
    {
        if (isEnemy)
            tagName = "Bullet";
        else   
            tagName = "VihuBullet";

        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            //do damage here
            float damage = float.Parse(other.name);
            TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
