using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float spawnDelay;

    [Header("직접 관리 영역")]
    public Transform[] enemyPaths;
    public Transform[] towerSpawnPoints;
    public string[] spawnTowerNamePool;
    public int[] towerPrice;

    [Header("UI 관련")]
    public Text t_score;
    public Text t_money;
    public Text t_wave;
    private float score;
    private float money;

    public Text[] t_buttons;

    public List<GameObject> enemyPool;

    private int[] towerSpawnState = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private int randint;
    private int towerCount = 0;
    public int towerIndex = 2;
    private int waveIndex = 0;
    private int waveSpawnCount = 0;
    private int curWave = 0;
    private int beforeWave = -1000;
    private int spawnIndex;

    [Header("웨이브 영역")]
    public s_wave[] wave; // waveNum, waveEnemyName, spawnDelay, maxSpawnCount


    private void Awake()
    {
        randint = Random.Range(0, 18);
        score = 0;
        money = 250;
        t_score.text = score.ToString();
        t_money.text = money.ToString();
        t_wave.text = "0";
        towerPrice[4] = Mathf.RoundToInt((towerPrice[0] + towerPrice[1] + towerPrice[2] + towerPrice[3])/5);
        t_buttons[4].text = towerPrice[4].ToString() + "G";
    }


    private IEnumerator WaveEnemySpawn()
    {
        while (true)
        {
            if(wave[waveIndex].waveNum == curWave && wave[waveIndex].maxSpawnCount > waveSpawnCount)
            {
                GameObject clone = ObjectManager.instance.GetObject(wave[waveIndex].waveEnemyName);
                enemyPool.Add(clone);
                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.paths = enemyPaths;
                enemy.g_GameManager = this.gameObject;
                enemy.SetUp();
                waveSpawnCount++;
                yield return new WaitForSeconds(wave[waveIndex].spawnDelay);
            }
            if(wave[waveIndex].maxSpawnCount == waveSpawnCount) EndWaveSystem();
            yield return null;
        }
    }

    private void EndWaveSystem()
    {
        waveSpawnCount = 0;
        waveIndex++;
        if (waveIndex >= wave.Length)
        {
            StopCoroutine("WaveEnemySpawn");
            return;
        }
        if(wave[waveIndex].waveNum != curWave)
        {
            StopCoroutine("WaveEnemySpawn");
        }
        return;
    }

    public void NextWave()
    {
        if(enemyPool.Count == 0 && beforeWave < curWave)
        {
            beforeWave = curWave;
            curWave++;
            t_wave.text = curWave.ToString();
            StartCoroutine("WaveEnemySpawn", 0.5f);
        }
        return;
    }

    public void SpawnTower(int towerIndex)
    {
        if (towerCount >= 18) return;
        while (towerSpawnState[randint] != 0)
        {
            randint = Random.Range(0, 18);
        }
        if (money < towerPrice[towerIndex]) return;

        SetMoney(-towerPrice[towerIndex]);
        towerPrice[towerIndex] = Mathf.RoundToInt(towerPrice[towerIndex] * 1.1f);
        t_buttons[towerIndex].text = towerPrice[towerIndex].ToString() + "G";

        if (towerIndex == 4)
        {
            towerIndex = Random.Range(0, 4);
        }

        GameObject clone = ObjectManager.instance.GetObject(spawnTowerNamePool[towerIndex]);
        clone.transform.position = towerSpawnPoints[randint].position;
        towerCount++;
        Tower tower = clone.GetComponent<Tower>();
        tower.g_GameManager = this.gameObject;
        towerSpawnState[randint] = 1;
    }

    public void OutPool(GameObject target)
    {
        enemyPool.Remove(target);
    }

    public void SetScore(float value)
    {
        score += value;
        t_score.text = score.ToString();
        return;
    }
    public void SetMoney(float value)
    {
        money += value;
        if(money > 9999)
        {
            money = 9999;
        }
        t_money.text = money.ToString();
        return;
    }
}
