using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public GameObject counter;
    public int damage;
    public float duration = 1.0f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("Counter");
        damage = counter.GetComponent<ScoreCounter>().score;
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Trigger")){}
        else if(other.gameObject.CompareTag("Player")){}
        else{
        BasicEnemy enemy = other.GetComponent<BasicEnemy>();
        if (enemy != null)
        {
            other.GetComponent<BasicEnemy>().TakeDamage(damage);
        }
        Destroy(gameObject);
        }
    }

    private void Update()
    {
        duration -= Time.deltaTime;

        if(duration<=0)
        {
            Destroy(gameObject);
        }
    }
}
