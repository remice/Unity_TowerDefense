using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private string destroyParticleName;

    public float damage;
    public GameObject target = null;

    private Vector3 direction;

    private void Update()
    {
        if (target == null || !target.activeSelf) DestroyBullet();
        else
        {
            direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    protected void DestroyBullet()
    {
        AudioManager.instance.SfxPlay("BulletDestroySound");
        EffectManager.instance.SpawnParticle(destroyParticleName, transform.position);
        this.gameObject.SetActive(false);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.HitBullet(damage);
            DestroyBullet();
        }
    }
}
