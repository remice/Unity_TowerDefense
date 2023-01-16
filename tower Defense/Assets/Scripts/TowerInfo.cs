using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
}

[System.Serializable]
public struct s_Tower
{
    public string name;
    public float damage;
    public float range;
    public float attackSpeed;
    public string bulletName;
}
