using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    public float health = 100f;

    public GameObject hitmarkerPrefab;
    public Transform hitmarkerPos;
    public Canvas canvas;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        var hitmarker = Instantiate(hitmarkerPrefab, hitmarkerPos.position, Quaternion.identity) as GameObject;
        hitmarker.transform.parent = canvas.gameObject.transform;
        Destroy(hitmarker, 0.2f);
    }
}
