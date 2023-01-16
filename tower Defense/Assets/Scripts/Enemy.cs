using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteChange))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected s_Enemy enemy;  //name, HP, speed, rotateSpeed, score, money

    public string EnemyName => enemy.name;
    public Transform[] paths;

    private int curPath;
    private int maxPath;
    private Vector3 direction;
    private float curHP;
    public GameObject g_GameManager;
    GameManager gameManager;
    private bool dead;
    public float slowPercent = 0;
    public float slowTime = 0;


    protected SpriteChange spriteRenderer;
    protected bool colorBlue = false;

    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteChange>();
    }

    private void OnEnable()
    {
        curPath = 0;
        curHP = enemy.HP;
        slowPercent = 0;
        slowTime = 0;
        colorBlue = true;
        dead = false;
    }

    protected virtual void Update()
    {
        transform.Rotate(Vector3.back * enemy.rotateSpeed * Time.deltaTime);
        slowTime -= Time.deltaTime;
        if(slowTime < 0 && colorBlue == true)
        {
            slowPercent = 0;
            colorBlue = false;
            spriteRenderer.ChangeSprite(0);
        }

        if(slowPercent != 0 && colorBlue == false)
        {
            colorBlue = true;
            spriteRenderer.ChangeSprite(1);
        }
    }

    public void SetUp()
    {
        gameManager = g_GameManager.GetComponent<GameManager>();
        maxPath = paths.Length;
        if (maxPath == 0)
            return;

        StopCoroutine("Move");

        transform.position = paths[curPath++].position;

        if (curPath >= maxPath)
        {
            DestroySelf();
            return;
        }

        direction = (paths[curPath].position - transform.position).normalized;

        StartCoroutine("Move");
    }

    private void DestroySelf()
    {
        gameManager.SetMoney(enemy.money);
        gameManager.OutPool(this.gameObject);
        this.gameObject.SetActive(false);
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, paths[curPath].position) < 0.03f)
            {
                SetUp();
            }
            transform.position += direction * enemy.speed * Time.deltaTime * (100 - slowPercent) / 100;

            yield return null;
        }
    }

    public void HitBullet(float damage)
    {
        curHP -= damage;
        if (curHP <= 0)
        {
            if (!dead)
            {
                dead = true;
                gameManager.SetScore(enemy.score);
                DestroySelf();
            }
        }
    }
}
