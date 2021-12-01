using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject enemy;

    float cooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown >= 10f)
            Instantiate(enemy, spawnLocations[Random.Range(0,4)].transform.position, Quaternion.identity);
    }
}
