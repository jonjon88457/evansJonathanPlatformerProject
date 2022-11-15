using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    public float startingHealth;
    public float currentHealth;
    public bool dead;

    [Header("IFrames")]
    public float iFramesDuration;
    public int flashNumber;
    private SpriteRenderer spriteRend;


    private void Awake()
    {
        currentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

            if(currentHealth > 0)
        {
            //take damage
            StartCoroutine(Invulnerability());
        }
            else if(!dead)
        {
            //Player
            if (GetComponent<PlayerMovement>() != null)
            {
                GetComponent<PlayerMovement>().enabled = false;
                SceneManager.LoadScene(2);
            }

            //Enemy
            if (GetComponentInParent<EnemyPatrol>() != null)
            {
                GetComponentInParent<EnemyPatrol>().enabled = false;
            }

            if (GetComponent<MeleeEnemy>() != null)
            {
                GetComponent<MeleeEnemy>().enabled = false;
                //GetComponent<Boss>
            }

            dead = true;
        }
        if (dead == true)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < flashNumber; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/(flashNumber * 2));
            spriteRend.color = Color.yellow;
            yield return new WaitForSeconds(iFramesDuration / (flashNumber * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
}
