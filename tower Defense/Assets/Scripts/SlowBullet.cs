using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBullet : Bullet
{
    [SerializeField]
    private float slowPercent;
    [SerializeField]
    private float slowTime;

    
    override protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.HitBullet(damage);
            enemy.slowPercent = this.slowPercent;
            enemy.slowTime = this.slowTime;
            DestroyBullet();
        }
    }
}
