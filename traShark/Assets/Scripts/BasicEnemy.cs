using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
        public Transform target;
        public int health = 100;
        public float speed = 3f;
        public float attack1Range = 1f;
        public int attack1Damage = 1;
        public float timeBetweenAttacks;
          // Use this for initialization
        public void TakeDamage (int damage)
        {
            health -= damage;

            if(health <= 0)
            {
                Death();
            }
        }
        void Start ()
        {
            gameObject.SetActive(false);
        }
    
        // Update is called once per frame
        void Update ()
        {
            
        }
         public void MoveToPlayer ()
        {
            //rotate to look at player
            transform.LookAt (target.position);
            transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
        
            //move towards player
            if (Vector3.Distance (transform.position, target.position) > attack1Range) 
            {
                    transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
            }
        }
 
        public void Rest ()
        {
 
        }

        public void Death()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<PlayerMovementBehaviour>().PlayerDamage(1);
        }
}