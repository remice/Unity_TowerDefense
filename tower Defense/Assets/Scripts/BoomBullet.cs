using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBullet : Bullet
{
    override protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject clone = ObjectManager.instance.GetObject("BoomEffect");
            clone.SetActive(true);
            clone.transform.position = this.transform.position;
            AttackTypeBoom boom = clone.GetComponent<AttackTypeBoom>();
            boom.damage = this.damage;
            DestroyBullet();
        }
    }
}
