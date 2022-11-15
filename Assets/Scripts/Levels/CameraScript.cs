using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x + 5, player.position.y + 5, player.position.z - 10);
    }
}