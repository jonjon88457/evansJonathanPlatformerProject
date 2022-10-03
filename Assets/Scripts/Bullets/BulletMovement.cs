using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;
    public int lifeTime;
    private float TargetX;
    private float TargetY;
    private Rigidbody2D idk;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        var hi = GameObject.Find("BulletTarget");
        target = hi;
        Invoke("LifeDone", lifeTime);
        idk = GetComponent<Rigidbody2D>();
        // idk.velocity = new Vector2(Camera.main.ScreenToWorldPoint(target.transform.position).x, Camera.main.ScreenToWorldPoint(target.transform.position).y);
        TargetX = target.transform.position.x;
        TargetY = target.transform.position.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 TargetPos = new Vector3(TargetX, TargetY, 0);
        //transform.position = Vector3.MoveTowards(TargetPos, TargetPos, step);
        Vector2 velocity = new Vector2((transform.position.x - TargetPos.x), (transform.position.y - TargetPos.y)).normalized * speed;
        idk.velocity = -velocity;
    }

    private void LifeDone()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
