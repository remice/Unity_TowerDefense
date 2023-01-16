using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
}

[System.Serializable]
public struct s_wave
{
    public int waveNum;
    public string waveEnemyName;
    public float spawnDelay;
    public int maxSpawnCount;
}