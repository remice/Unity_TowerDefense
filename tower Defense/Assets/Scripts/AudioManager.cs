using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    Sound[] sfx = null;

    [SerializeField]
    AudioSource[] sfxPlayer = null;

    private void Start()
    {
        instance = this;
    }

    public void SfxPlay(string soundName)
    {
        for(int i = 0; i < sfxPlayer.Length; i++)
            if(!sfxPlayer[i].isPlaying)
                for (int j = 0; j < sfx.Length; j++)
                    if(sfx[j].name == soundName)
                    {
                        sfxPlayer[i].clip = sfx[j].clip;
                        sfxPlayer[i].Play();
                        return;
                    }
    }
}
