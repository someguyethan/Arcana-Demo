using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerContainer : MonoBehaviour
{
    public int health;
    float cooldown = 0f;
    public GameObject vignette;
    bool isHit = false;

    private void Awake()
    {
        health = 2;
    }

    private void Update()
    {
        if (health <= 0)
            SceneManager.LoadScene("GameOver");

        if (health == 1)
            vignette.SetActive(true);
        else 
            vignette.SetActive(false);

        cooldown += Time.deltaTime;

        if (isHit == true && cooldown > 1f)
        {
            TakeDamage(1);
            Debug.Log("HIT " + health.ToString());
            cooldown = 0f;
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
            isHit = true;
    }
    public void OnTriggerExit(Collider collision)
    {
        isHit = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
