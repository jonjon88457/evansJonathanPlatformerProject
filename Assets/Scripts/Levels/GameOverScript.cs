using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Health hp;
    public PlayerMovement PlayerMovement;
  public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        gameObject.SetActive(false);
        hp.currentHealth = 1;
        PlayerMovement.GetComponent<PlayerMovement>().enabled = true;
        hp.dead = false;
    }
}
