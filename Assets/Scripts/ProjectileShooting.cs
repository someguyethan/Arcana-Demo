using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    public CapsuleCollider col;

    private bool doFire = true;
    private bool doLightning = false;
    private bool doBeam = false;
    private float beamCooldown = 10000f;
    private float projectileCooldown = 10000f;
    private float hitscanCooldown = 10000f;

    public float moveMulti = 500f;
    public float fireMulti = 500f;

    public Button fireButton;

    bool fireButtonDown = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        beamCooldown += 1f * Time.deltaTime * fireMulti;
        projectileCooldown += 1f * Time.deltaTime * fireMulti;
        hitscanCooldown += 1f * Time.deltaTime * fireMulti;

        if (fireButtonDown)
            DoShoot();
    }
    void Update()
    {
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
    }
    public void SwitchFireball()
    {
        doFire = true;
        doLightning = false;
        doBeam = false;
    }
    public void SwitchLightning()
    {
        doFire = false;
        doLightning = true;
        doBeam = false;
    }
    public void SwitchBeam()
    {
        doFire = false;
        doLightning = false;
        doBeam = true;
    }

    public void DoShoot()
    {
        if (doFire)
        {
            if (projectileCooldown >= projectileRate)
            {
                SoundManagement.PlaySound("fire_fireball");
                projectileCooldown = 0f;
                var projectileInstance = Instantiate(projectile, cam.transform.position, cam.rotation) as GameObject;
                projectileInstance.GetComponent<Rigidbody>().velocity = cam.forward * projectileSpeed * Time.deltaTime * moveMulti;

                Physics.IgnoreCollision(projectileInstance.GetComponent<Collider>(), col);

                Destroy(projectileInstance, 10);
            }
        }
        else if (doLightning)
        {
            if (hitscanCooldown >= hitscanRate)
            {
                SoundManagement.PlaySound("fire_lightning");
                var lightningInstance = Instantiate(lightningEffect, WeaponPos.position, cam.rotation) as GameObject;
                Destroy(lightningInstance, 0.5f);
                hitscanCooldown = 0f;
                RaycastHit hit;
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, hitscanRange))
                {
                    SoundManagement.PlaySound("lightning_collide");
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
            SoundManagement.PlaySound("fire_dray");
            var beamInstance = Instantiate(beamEffect, WeaponPos.position, cam.rotation) as GameObject;
            Destroy(beamInstance, 0.5f);
            if (beamCooldown >= beamRate)
            {
                beamCooldown = 0f;
                RaycastHit hit;
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, beamRange))
                {
                    SoundManagement.PlaySound("dray_collide");
                    EnemyContainer enemy = hit.transform.GetComponent<EnemyContainer>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(beamDamage);
                    }
                }
            }
        }
    }
    public void OnDown()
    {
        fireButtonDown = true;
    }
    public void OnUp()
    {
        fireButtonDown = false;
    }
}