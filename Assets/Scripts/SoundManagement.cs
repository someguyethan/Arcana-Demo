using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
    //To play a sound, in any script use ---> SoundManagement.PlaySound("walk");
    //NOTE: You the names are from the switch cases not the resources folder

    public static AudioClip walkSound, sprintSound, jumpSound, fireFireballSound, fireLightningSound, fireDRaySound, hurtSound,
                            grappleHookSound, fireballCollisionSound, lightningCollsionSound, dRayCollisionSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        walkSound = Resources.Load<AudioClip>("walk");
        sprintSound = Resources.Load<AudioClip>("sprint");
        jumpSound = Resources.Load<AudioClip>("jump");
        fireFireballSound = Resources.Load<AudioClip>("shootfireball");
        fireLightningSound = Resources.Load<AudioClip>("shootlightning");
        fireDRaySound = Resources.Load<AudioClip>("shootdray");
        hurtSound = Resources.Load<AudioClip>("hurt");
        grappleHookSound = Resources.Load<AudioClip>("grapplehook");
        fireballCollisionSound = Resources.Load<AudioClip>("fireballcollision");
        lightningCollsionSound = Resources.Load<AudioClip>("lightningcollision");
        dRayCollisionSound = Resources.Load<AudioClip>("draycollision");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "walk":
                audioSrc.PlayOneShot(walkSound, 0.8f);
                break;

            case "sprint":
                audioSrc.PlayOneShot(sprintSound, 0.8f);
                break;

            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;

            case "fire_fireball":
                audioSrc.PlayOneShot(fireFireballSound);
                break;

            case "fire_lightning":
                audioSrc.PlayOneShot(fireLightningSound);
                break;

            case "fire_dray":
                audioSrc.PlayOneShot(fireDRaySound, 0.8f);
                break;

            case "hurt":
                audioSrc.PlayOneShot(hurtSound, 0.8f);
                break;

            case "grapplehook":
                audioSrc.PlayOneShot(grappleHookSound, 0.8f);
                break;

            case "fireball_collide":
                audioSrc.PlayOneShot(fireballCollisionSound, 0.8f);
                break;

            case "lightning_collide":
                audioSrc.PlayOneShot(lightningCollsionSound, 0.8f);
                break;

            case "dray_collide":
                audioSrc.PlayOneShot(dRayCollisionSound, 0.8f);
                break;
        }
    }
}
