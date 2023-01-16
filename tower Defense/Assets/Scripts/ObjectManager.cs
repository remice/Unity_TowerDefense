using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;

    [SerializeField]
    private GameObject basicEnemyPrefab;
    [SerializeField]
    private GameObject heavyEnemyPrefab;
    [SerializeField]
    private GameObject boosterEnemyPrefab;
    [SerializeField]
    private GameObject basicTowerPrefab;
    [SerializeField]
    private GameObject doubleTowerPrefab;
    [SerializeField]
    private GameObject slowTowerPrefab;
    [SerializeField]
    private GameObject boomTowerPrefab;
    [SerializeField]
    private GameObject basicBulletPrefab;
    [SerializeField]
    private GameObject smallBulletPrefab;
    [SerializeField]
    private GameObject slowBulletPrefab;
    [SerializeField]
    private GameObject boomBulletPrefab;
    [SerializeField]
    private GameObject boomEffectPrefab;
    // ↑ Prefabs

    [SerializeField]
    private int basicEnemySpawnCount;
    [SerializeField]
    private int heavyEnemySpawnCount;
    [SerializeField]
    private int boosterEnemySpawnCount;
    [SerializeField]
    private int basicTowerSpawnCount;
    [SerializeField]
    private int doubleTowerSpawnCount;
    [SerializeField]
    private int slowTowerSpawnCount;
    [SerializeField]
    private int boomTowerSpawnCount;
    [SerializeField]
    private int basicBulletSpawnCount;
    [SerializeField]
    private int smallBulletSpawnCount;
    [SerializeField]
    private int slowBulletSpawnCount;
    [SerializeField]
    private int boomBulletSpawnCount;
    [SerializeField]
    private int boomEffectSpawnCount;
    // ↑ Object Pool Size

    private GameObject[] basicEnemyPool;
    private GameObject[] heavyEnemyPool;
    private GameObject[] boosterEnemyPool;
    private GameObject[] basicTowerPool;
    private GameObject[] doubleTowerPool;
    private GameObject[] slowTowerPool;
    private GameObject[] boomTowerPool;
    private GameObject[] basicBulletPool;
    private GameObject[] smallBulletPool;
    private GameObject[] slowBulletPool;
    private GameObject[] boomBulletPool;
    private GameObject[] boomEffectPool;

    private int enemyIndex = 0;
    private int heavyEnemyIndex = 0;
    private int boosterEnemyIndex = 0;
    private int bulletIndex = 0;
    private int smallBulletIndex = 0;
    private int slowBulletIndex = 0;
    private int boomBulletIndex = 0;
    private int boomEffectIndex = 0;

    private void Awake()
    {
        instance = this;

        basicEnemyPool = SpawnPools(basicEnemyPrefab, basicEnemySpawnCount);
        heavyEnemyPool = SpawnPools(heavyEnemyPrefab, heavyEnemySpawnCount);
        boosterEnemyPool = SpawnPools(boosterEnemyPrefab, boosterEnemySpawnCount);
        basicTowerPool = SpawnPools(basicTowerPrefab, basicTowerSpawnCount);
        doubleTowerPool = SpawnPools(doubleTowerPrefab, doubleTowerSpawnCount);
        slowTowerPool = SpawnPools(slowTowerPrefab, slowTowerSpawnCount);
        boomTowerPool = SpawnPools(boomTowerPrefab, boomTowerSpawnCount);
        basicBulletPool = SpawnPools(basicBulletPrefab, basicBulletSpawnCount);
        smallBulletPool = SpawnPools(smallBulletPrefab, smallBulletSpawnCount);
        slowBulletPool = SpawnPools(slowBulletPrefab, slowBulletSpawnCount);
        boomBulletPool = SpawnPools(boomBulletPrefab, boomBulletSpawnCount);
        boomEffectPool = SpawnPools(boomEffectPrefab, boomEffectSpawnCount);
        // ↑ Creat & Insert Object in Pool
    }

    public GameObject[] SpawnPools(GameObject prefab, int count)
    {
        GameObject[] pool = new GameObject[count];
        for(int i = 0; i < count; i++)
        {
            GameObject clone = Instantiate(prefab);
            pool[i] = clone;
            clone.SetActive(false);
        }
        return pool;
    }

    public GameObject GetObject(string objectName)
    {
        int objectIndex = 0;
        switch (objectName)
        {
            case "BasicEnemy":
                while (true)
                {
                    if (enemyIndex >= basicEnemySpawnCount - 1)
                    {
                        enemyIndex = -1;
                    }
                    enemyIndex++;
                    basicEnemyPool[enemyIndex].SetActive(true);
                    return basicEnemyPool[enemyIndex];
                }
            case "HeavyEnemy":
                while (true)
                {
                    if (heavyEnemyIndex >= heavyEnemySpawnCount - 1)
                    {
                        heavyEnemyIndex = -1;
                    }
                    heavyEnemyIndex++;
                    heavyEnemyPool[heavyEnemyIndex].SetActive(true);
                    return heavyEnemyPool[heavyEnemyIndex];
                }
            case "BoosterEnemy":
                while (true)
                {
                    if (boosterEnemyIndex >= boosterEnemySpawnCount - 1)
                    {
                        boosterEnemyIndex = -1;
                    }
                    boosterEnemyIndex++;
                    boosterEnemyPool[boosterEnemyIndex].SetActive(true);
                    return boosterEnemyPool[boosterEnemyIndex];
                }
            case "BasicTower":
                while (true)
                {
                    if (!basicTowerPool[objectIndex].activeSelf)
                    {
                        basicTowerPool[objectIndex].SetActive(true);
                        return basicTowerPool[objectIndex];
                    }
                    objectIndex++;
                }
            case "DoubleTower":
                while (true)
                {
                    if (!doubleTowerPool[objectIndex].activeSelf)
                    {
                        doubleTowerPool[objectIndex].SetActive(true);
                        return doubleTowerPool[objectIndex];
                    }
                    objectIndex++;
                }
            case "SlowTower":
                while (true)
                {
                    if (!slowTowerPool[objectIndex].activeSelf)
                    {
                        slowTowerPool[objectIndex].SetActive(true);
                        return slowTowerPool[objectIndex];
                    }
                    objectIndex++;
                }
            case "BoomTower":
                while (true)
                {
                    if (!boomTowerPool[objectIndex].activeSelf)
                    {
                        boomTowerPool[objectIndex].SetActive(true);
                        return boomTowerPool[objectIndex];
                    }
                    objectIndex++;
                }
            case "BasicBullet":
                while (true)
                {
                    if (bulletIndex >= basicBulletSpawnCount-1)
                    {
                        bulletIndex = -1;
                    }
                    bulletIndex++;
                    basicBulletPool[bulletIndex].SetActive(true);
                    return basicBulletPool[bulletIndex];
                }
            case "SmallBullet":
                while (true)
                {
                    if (smallBulletIndex >= smallBulletSpawnCount - 1)
                    {
                        smallBulletIndex = -1;
                    }
                    smallBulletIndex++;
                    smallBulletPool[smallBulletIndex].SetActive(true);
                    return smallBulletPool[smallBulletIndex];
                }
            case "SlowBullet":
                while (true)
                {
                    if (slowBulletIndex >= slowBulletSpawnCount - 1)
                    {
                        slowBulletIndex = -1;
                    }
                    slowBulletIndex++;
                    slowBulletPool[slowBulletIndex].SetActive(true);
                    return slowBulletPool[slowBulletIndex];
                }
            case "BoomBullet":
                while (true)
                {
                    if (boomBulletIndex >= boomBulletSpawnCount - 1)
                    {
                        boomBulletIndex = -1;
                    }
                    boomBulletIndex++;
                    boomBulletPool[boomBulletIndex].SetActive(true);
                    return boomBulletPool[boomBulletIndex];
                }
            case "BoomEffect":
                while (true)
                {
                    if (boomEffectIndex >= boomEffectSpawnCount - 1)
                    {
                        boomEffectIndex = -1;
                    }
                    boomEffectIndex++;
                    boomEffectPool[boomEffectIndex].SetActive(true);
                    return boomEffectPool[boomEffectIndex];
                }
        }
        return null;
    }
}
