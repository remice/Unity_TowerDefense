using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private enum TowerState { SearchTarget, AttackTarget };

    public s_Tower tower; //name, damage, range, attackSpeed, bulletName

    [SerializeField]
    private Transform[] bulletSpawnPoint;
    
    public GameObject g_GameManager;
    GameManager gameManager;

    private GameObject target = null;

    private void Start()
    {
        gameManager = g_GameManager.GetComponent<GameManager>();
        StartCoroutine("SearchToTarget");
    }
    private void Update()
    {
        RotateTower();
    }

    private void RotateTower()
    {
        if (target == null || !target.activeSelf) return;
        float dx = target.transform.position.x - transform.position.x;
        float dy = target.transform.position.y - transform.position.y;
        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, -(angle - 90));
    }

    private IEnumerator SearchToTarget()
    {
        StopCoroutine("AttackToTarget");
        target = null;
        while (true)
        {
            int i = 0;
            while (gameManager.enemyPool.Count > i)
            {
                GameObject temp_target = gameManager.enemyPool[i];
                if (target == null || Vector3.Distance(transform.position, target.transform.position) > Vector3.Distance(transform.position, temp_target.transform.position))
                {
                    target = temp_target;
                }
                i++;
            }
            if (target != null)
            {
                StartCoroutine("AttackToTarget");
            }
            yield return null;
        }
    }
    
    private IEnumerator AttackToTarget()
    {
        StopCoroutine("SearchToTarget");
        while(true)
        {
            RotateTower();
            if (target == null || !target.activeSelf)
            {
                StartCoroutine("SearchToTarget");
            }
            else
            {
                switch (tower.name)
                {
                    case "BasicTower":
                        SpawnBullet("BasicBullet", 0);
                        break;
                    case "DoubleTower":
                        SpawnBullet("SmallBullet", 0);
                        SpawnBullet("SmallBullet", 1);
                        break;
                    case "SlowTower":
                        SpawnBullet("SlowBullet", 0);
                        break;
                    case "BoomTower":
                        SpawnBullet("BoomBullet", 0);
                        break;
                }
            }
            yield return new WaitForSeconds(tower.attackSpeed);
        }
    }

    private void SpawnBullet(string bulletName, int spawnPointIndex)
    {
        GameObject clone = ObjectManager.instance.GetObject(bulletName);
        clone.transform.position = bulletSpawnPoint[spawnPointIndex].position;
        Bullet bullet = clone.GetComponent<Bullet>();
        bullet.target = target;
        bullet.damage = tower.damage;
        return;
    }
}
