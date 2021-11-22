using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public GameObject explosion;
    public GameObject player;
    private bool collided;

    public LayerMask enemies;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "Player" && !collided)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                EnemyContainer enemy = collision.gameObject.GetComponent<EnemyContainer>();
                enemy.TakeDamage(player.GetComponent<ProjectileShooting>().projectileDamage);
            }
            explosionAOE();
            SoundManagement.PlaySound("fireball_collide");
            var explosionInstance = Instantiate(explosion, gameObject.GetComponent<Rigidbody>().position, transform.rotation) as GameObject;
            Destroy(explosionInstance, 0.5f);
            collided = true;
            Destroy(gameObject);
        }
    }

    private void explosionAOE()
    {
        Collider[] colliders = Physics.OverlapSphere(gameObject.GetComponent<Rigidbody>().position, 3f, enemies);
        foreach (Collider c in colliders)
        {
            if (c.gameObject.tag == "Enemy")
            {
                EnemyContainer enemy = c.gameObject.GetComponent<EnemyContainer>();
                //float damage = player.GetComponent<ProjectileShooting>().projectileDamage;
                float damage = calculateDamage(Vector3.Distance(gameObject.GetComponent<Rigidbody>().position, c.transform.position),
                                               player.GetComponent<ProjectileShooting>().projectileDamage);
                enemy.TakeDamage(damage);
            }
        }
    }

    private float calculateDamage (float dist, float dam)
    {
        return dam;
        //return Mathf.Lerp(dam, 0f, Mathf.Min(dist, 1f));
    }
}
