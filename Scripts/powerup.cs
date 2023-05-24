using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Polyperfect.People;

//  we programmed this whole file!!!!!!!!

public class powerup : MonoBehaviour
{
    public float multiplier = 1.4f;
    public float slower = 4f;
    public int healthBonus = 20;
    private PlayerController pc;
    private healthbar hb;
    public GameObject pickupEffect;
    public GameObject lights;

    public bool isInfluenced = false;

    void Start()
    {
        lights = GameObject.Find("spotlights");
        lights.SetActive(false);
    }

    void Update()
    {
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("fire"))
            {
                firePowerup(other);
            }
            if (gameObject.CompareTag("health"))
            {
                healthPickup(other);
            }
            if (gameObject.CompareTag("badHealth"))
            {
                badHealthPickup(other);
            }
            if (gameObject.CompareTag("slow"))
            {
                slowPowerup(other);
            }
        }
    }

    void firePowerup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        //GameObject.Find("spotlight").SetActive(true);
        pc = player.GetComponent<PlayerController>();
        pc.walkSpeed = pc.walkSpeed * multiplier;
        pc.runSpeed = pc.runSpeed * multiplier;
        Destroy(gameObject);
    }

    void slowPowerup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        //GameObject.Find("spotlight").SetActive(true);
        pc = player.GetComponent<PlayerController>();
        pc.walkSpeed = pc.walkSpeed / slower;
        pc.runSpeed = pc.runSpeed / slower;
        Destroy(gameObject);
        lights.SetActive(true);
        GameObject thirdcam = GameObject.Find("Camera");
        thirdcam.transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * 60, 90) - 45);
        //isInfluenced = true;
    }

    void healthPickup(Collider player)
    {
        hb = GameObject.Find("healthbar").GetComponent<healthbar>();
        Debug.Log("health: " + hb.currentHealth);
        Instantiate(pickupEffect, transform.position, transform.rotation);
        hb.AddHealth(20);
        Debug.Log("health: " + hb.currentHealth);
        Destroy(gameObject);
    }

    void badHealthPickup(Collider player)
    {
        hb = GameObject.Find("healthbar").GetComponent<healthbar>();
        Debug.Log("health: " + hb.currentHealth);
        Instantiate(pickupEffect, transform.position, transform.rotation);
        hb.TakeDamage(20);
        Debug.Log("health: " + hb.currentHealth);
        Destroy(gameObject);
    }
}