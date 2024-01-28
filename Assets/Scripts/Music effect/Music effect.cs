using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Musiceffect : MonoSingleton<Musiceffect>
{
    public AudioClip soundEffect; // 音效文件
    private AudioSource audioSource;

    private void Start()
    {
        // 获取 AudioSource 组件
        audioSource = GetComponent<AudioSource>();

        // 分配音效文件给 AudioSource 组件
        audioSource.clip = soundEffect;
    }
    public void PlaySoundEffect()
    {
        // 检查 AudioSource 组件是否存在以及音效文件是否分配
        if (audioSource != null && audioSource.clip != null)
        {
            // 播放音效
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource component or sound effect is missing.");
        }
    }
    
}
