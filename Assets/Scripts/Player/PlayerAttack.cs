using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackCooldown;
    public Transform bulletSpawn;
    public GameObject[] bullets;
    private PlayerMovement playerMovement;
    private float cooldownTimer = 999;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Shoot();
        }
       
        cooldownTimer += Time.deltaTime;
    }

    private void Shoot()
    {
        cooldownTimer = 0;

        bullets[CycleBullets()].transform.position = bulletSpawn.position;
        bullets[CycleBullets()].GetComponent<BulletScript>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int CycleBullets()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
