using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public float rps = 2;
    public GameObject firePoint;
    public GameObject bulletPrefab;
    
    public float bulletForce = 30f;
    
    private float spriteTime = 0;
    private float nextFire = 0;
    
    private GameObject newProjectile;
    
    // Update is called once per frame
    void Update()
    {
        spriteTime = spriteTime + Time.deltaTime;
        
        
        if (Input.GetButton("Fire1") )
        {
            if (spriteTime >= nextFire)
            {
                nextFire = 1f/rps;
                spriteTime = 0.0F;
                shoot();
            }
        }
    }
    
    void shoot()
    {
        newProjectile = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        
        Rigidbody2D rb_projectile = newProjectile.GetComponent<Rigidbody2D>();
        rb_projectile.AddForce( firePoint.transform.right * bulletForce, ForceMode2D.Impulse);
        
        Destroy (newProjectile, 5f);
    }
    
    void FixedUpdate()
    {
        
    }
}
