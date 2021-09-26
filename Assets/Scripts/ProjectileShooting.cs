using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour
{
    public GameObject projectile;
    public GameObject lightningEffect;
    public GameObject beamEffect;
    public Transform WeaponPos;
    public float projectileSpeed = 50f;
    public float projectileDamage = 25f;
    public float hitscanDamage = 80f;
    public float hitscanRange = 100f;
    public float beamDamage = 3f;
    public float beamRange = 25f;
    public float projectileRate = 100f;
    public float hitscanRate = 100f;
    public float beamRate = 10f;
    public Transform cam;

    private bool doFire = true;
    private bool doLightning = false;
    private bool doBeam = false;
    private float beamCooldown = 10000f;
    private float projectileCooldown = 10000f;
    private float hitscanCooldown = 10000f;

    // Update is called once per frame
    void Update()
    {
        beamCooldown += 1f;
        projectileCooldown += 1f;
        hitscanCooldown += 1f;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            doFire = true;
            doLightning = false;
            doBeam = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            doFire = false;
            doLightning = true;
            doBeam = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            doFire = false;
            doLightning = false;
            doBeam = true;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (doFire)
            {
                if (projectileCooldown >= projectileRate)
                {
                    projectileCooldown = 0f;
                    var projectileInstance = Instantiate(projectile, cam.transform.position, cam.rotation) as GameObject;
                    projectileInstance.GetComponent<Rigidbody>().velocity = cam.forward * projectileSpeed;

                    Physics.IgnoreCollision(projectileInstance.GetComponent<Collider>(), GetComponent<Collider>());

                    Destroy(projectileInstance, 10);
                }
            }
            else if (doLightning)
            {
                if (hitscanCooldown >= hitscanRate)
                {
                    var lightningInstance = Instantiate(lightningEffect, WeaponPos.position, cam.rotation) as GameObject;
                    Destroy(lightningInstance, 0.5f);
                    hitscanCooldown = 0f;
                    RaycastHit hit;
                    if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, hitscanRange))
                    {
                        EnemyContainer enemy = hit.transform.GetComponent<EnemyContainer>();
                        if (enemy != null)
                        {
                            enemy.TakeDamage(hitscanDamage);
                        }
                    }
                }
            }
            else if (doBeam)
            {
                var beamInstance = Instantiate(beamEffect, WeaponPos.position, cam.rotation) as GameObject;
                Destroy(beamInstance, 0.5f);
                if (beamCooldown >= beamRate)
                {
                    beamCooldown = 0f;
                    RaycastHit hit;
                    if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, beamRange))
                    {
                        EnemyContainer enemy = hit.transform.GetComponent<EnemyContainer>();
                        if (enemy != null)
                        {
                            enemy.TakeDamage(beamDamage);
                        }
                    }
                }
            }
        }
    }
}
