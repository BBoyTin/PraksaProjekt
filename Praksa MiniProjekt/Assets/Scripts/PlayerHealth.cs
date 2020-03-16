using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;

    public GameObject deathExplosion;
    public RectTransform healthBar;

    public TextMeshProUGUI brojZivota;

    public GameObject gameOverScreen;

    float currentHealth;

    bool isDead = false;

    float maxWidthHealth;



    int lives = 1;
    Vector3 respawnPosition;
    Quaternion respawnRotation;


    void Awake()
    {
        maxWidthHealth = healthBar.rect.width;
    }

    void Start()
    {
        currentHealth = maxHealth;

        respawnPosition = transform.position;
        respawnRotation = transform.rotation;

        brojZivota.text = "X " + lives;
    }


    public void TakeDamage(float dmg)
    {

        currentHealth -= dmg;

        //Debug.Log("current player health" + currentHealth);

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar(currentHealth / maxHealth);


        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {

        isDead = true;
        CancelInvoke();
        Instantiate(deathExplosion, transform.position, transform.rotation);
        this.gameObject.SetActive(false);

        if (lives <= 0)
        {
            Invoke("GameOver", 2f);
        }
        else
        {
            Invoke("Respawn", 5f);
        }



    }


    public float getHealth()
    {
        return currentHealth;
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UpdateHealthBar(float percent)
    {
        healthBar.sizeDelta = new Vector2(maxWidthHealth * percent, 10f);
    }



    public void Repair(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHealthBar(currentHealth / maxHealth);
    }


    public void Respawn()
    {
        lives--;
        brojZivota.text = "X " + lives;
        transform.position = respawnPosition;
        transform.rotation = respawnRotation;
        currentHealth = maxHealth;
        UpdateHealthBar(1);

        this.gameObject.SetActive(true);
        
        isDead = false;
    }

    public void AddLife()
    {
        lives=lives + 1;
        brojZivota.text = "X " + lives;
    }
}
