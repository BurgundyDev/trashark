using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class EnemyTerritory : MonoBehaviour
 {
        public BoxCollider2D territory;
        GameObject player;
        bool playerInTerritory;

        public GameObject enemy;
        BasicEnemy basicenemy;
 
         // Use this for initialization
        void Start ()
        {
            player = GameObject.FindGameObjectWithTag ("Player");
            basicenemy = enemy.GetComponent <BasicEnemy> ();
            playerInTerritory = false;
        }
     
         // Update is called once per frame
        void Update ()
        {
            if (playerInTerritory == true)
            {
                basicenemy.MoveToPlayer ();
            }
 
            if (playerInTerritory == false)
            {
                basicenemy.Rest ();
            }
        }
 
        void OnTriggerEnter2D (Collider2D other)
        {
            if (other.gameObject == player)
            {
                playerInTerritory = true;
            }
        }
     
        void OnTriggerExit2D (Collider2D other)
        {
            if (other.gameObject == player) 
            {
                    playerInTerritory = false;
            }
        }
 }
