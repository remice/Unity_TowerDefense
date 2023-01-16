using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterEnemy : Enemy
{
    [SerializeField]
    private float maxBoosterDelay = 3;
    [SerializeField]
    private float endBoosterDelay = 4;

    private float curBoosterDelay = 0;
    private bool isBooster = false;

    override protected void Update()
    {
        transform.Rotate(Vector3.back * enemy.rotateSpeed * Time.deltaTime);

        slowTime -= Time.deltaTime;
        curBoosterDelay += Time.deltaTime;


        if (slowTime < 0 && colorBlue == true)
        {
            slowPercent = 0;
            colorBlue = false;
            spriteRenderer.ChangeSprite(0);
        }

        if (slowPercent > 0 && colorBlue == false && !isBooster)
        {
            colorBlue = true;
            spriteRenderer.ChangeSprite(1);
        }

        if (curBoosterDelay > maxBoosterDelay)
        {
            if (!isBooster)
            {
                spriteRenderer.ChangeSprite(2);
            }
            colorBlue = false;
            isBooster = true;
            slowPercent = -70;
        }

        if (curBoosterDelay > endBoosterDelay)
        {
            isBooster = false;
            slowPercent = 0;
            curBoosterDelay = 0;
            spriteRenderer.ChangeSprite(0);
        }
    }
}
