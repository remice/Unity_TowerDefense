using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
}

[System.Serializable]
public struct s_Enemy
{
    public string name;
    public float HP;
    public float speed;
    public float rotateSpeed;
    public float score;
    public float money;
}
