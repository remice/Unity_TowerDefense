using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class particle
{
    public string name;
    public ParticleSystem particleEffect;
}
public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;

    [SerializeField]
    private particle[] particleEffectPools;


    private void Awake()
    {
        instance = this;
    }

    public void SpawnParticle(string particleName, Vector3 spawnPosition)
    {
        for(int i = 0; i < particleEffectPools.Length; i++)
        {
            if(particleEffectPools[i].name == particleName)
            {
                GameObject clone = Instantiate(particleEffectPools[i].particleEffect.gameObject);
                clone.transform.position = spawnPosition;
                Destroy(clone, 0.5f);
            }
        }
    }
}
