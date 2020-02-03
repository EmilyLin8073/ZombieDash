using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For spike object to damage the enemy
public class DamageEnemy : MonoBehaviour
{
    //Variable for damage enemy
    public int damageGivenEnemy = 50;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //When player touch the object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DamageEnemy(damageGivenEnemy);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DamageEnemy(damageGivenEnemy);
        }
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        other.GetComponent<EnemyController>().DamageEnemy(damageGivenEnemy);
    //    }
    //}

    //private void OnCollisionStay2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        other.gameObject.DamageEnemy(damageGivenEnemy);
    //    }
    //}
}
