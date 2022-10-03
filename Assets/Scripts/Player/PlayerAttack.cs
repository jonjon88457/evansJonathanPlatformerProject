using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackCooldown;
    private PlayerController playerMovement;
    private float cooldownTimer = 999;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Shoot();

        cooldownTimer += Time.deltaTime;
    }

    private void Shoot()
    {
        cooldownTimer = 0;
    }
}
