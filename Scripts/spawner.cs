using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  we programmed this whole file!!!!!!!!

public class spawner : MonoBehaviour
{
    public GameObject projectile;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pauseMenu.isPaused)
        {
            GameObject fireball = Instantiate(projectile, transform) as GameObject;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 20;
            if (fireball.transform.position.x > 10)
                Destroy(fireball);
        }
    }
}
