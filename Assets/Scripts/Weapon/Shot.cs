using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
        //Disparar
   public Transform spawnPoint;
   public GameObject bullet;
   public float shotForce= 1500f;
   public float shotRate = 0.5f;


   private float shotRateTime = 0f;
  
        // Input.GetKeyDown(KeyCode.Mouse1)
 
    void Update()
    {   //Disparar
        if(Input.GetButtonDown("Fire1"))
        {
        // Tiempo del disparo
            if(Time.time > shotRateTime)
            {
            GameObject newBullet ;
            newBullet= Instantiate(bullet,spawnPoint.position, spawnPoint.rotation);
        //Mover las balas
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
        // Tiempo del disparo
            shotRateTime= Time.time + shotRate;
        
        // Destruir la bala en 5 segundos

            Destroy(newBullet,5);
            }
        }


    }
}
