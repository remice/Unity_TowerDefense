using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTypeBoom : MonoBehaviour
{
    public float damage;

    private void OnEnable()
    {
        Invoke("DestroyBoomEffect", 0.2f);
    }

    private void DestroyBoomEffect()
    {
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.HitBullet(damage);
        }
    }
}
