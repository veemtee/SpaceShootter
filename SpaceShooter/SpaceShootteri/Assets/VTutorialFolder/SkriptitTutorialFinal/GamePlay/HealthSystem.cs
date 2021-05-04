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
    private DeathSystem deathScript;
    private bool dead;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (isEnemy)
            tagName = "Bullet";
        else   
            tagName = "VihuBullet";

        currentHealth = maxHealth;
    }

    private void Start()
    {
        if (isEnemy) LevelManager.instance.RegisterEnemy();
        deathScript = GetComponent<DeathSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            if (!isEnemy)
                LevelManager.instance.PlayerHit();
            //iskemäefektille osumakulmaa KAI eli laske tagien tarkka osumakohta, triggerin keskeltä suunta osumakohtaan ja luo fx objekti poolista hae
            //hiteffecti ja laita se tarkkaan osumakohtaan ja katsontasuunta kohti osutun objektin keskelle nice?!? voisko lyya maanantaiprojektiin tulitus
            //effektiin esim miehistönkuljetusvaunuun JÖÖ

            Vector3 triggerPosition = other.ClosestPointOnBounds(transform.position);
            Vector3 direction = triggerPosition - transform.position;
            GameObject fx = PoolingManager.poolingInstance.UseObject(hitEffect, triggerPosition, Quaternion.LookRotation(direction));
            PoolingManager.poolingInstance.ReturnObject(fx, 1f);
            //do damage here
            float damage = float.Parse(other.name);
            TakeDamage(damage);

            PoolingManager.poolingInstance.ReturnObject(other.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckHealth();
        UpdateUI();
    }

    void CheckHealth()
    {
        if (currentHealth <= 0f)
        {
            if (healthBar != null)
                healthBar.transform.parent.gameObject.SetActive(false);

            //TO-DO:die
            if (deathScript != null)
                deathScript.Death();

            //TO-DO:if its enemy, then add points

            if (isEnemy && !dead)
            {
                dead = true;
                gameObject.tag = "Untagged";
                LevelManager.instance.AddEnemyKill(); //(Random.Range(minScore, maxScore));
            }
        }
    }

    void UpdateUI()
    {
        if (healthBar != null)
        {
            Vector3 scale = Vector3.one;
            float value = currentHealth / maxHealth;
            scale.x = value;
            healthBar.transform.localScale = scale;
        }
    }
}
