using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Musiceffect : MonoSingleton<Musiceffect>
{
        public static Musiceffect instance; // 单例

    public AudioSource soundEffectAudioSource; // 用于播放音效的 AudioSource 组件
    public AudioClip shit;
    public AudioClip jump;
    public AudioClip cxk;
    public AudioClip elbow;
    public AudioClip bullet;
    private void Awake()
        {
            // 设置单例
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            // 确保音效管理器不会被销毁
            DontDestroyOnLoad(gameObject);
        }

    // 播放音效
    public void PlaySoundShit( float volume = 1f, bool loop = false)
        {
            // 检查音效是否为空
            if (shit == null)
            {
                Debug.LogWarning("Trying to play null audio clip.");
                return;
            }

            // 设置音量和循环状态
            soundEffectAudioSource.volume = volume;
            soundEffectAudioSource.loop = loop;

            // 播放音效
            soundEffectAudioSource.clip = shit;
            soundEffectAudioSource.Play();
        }
    public void PlaySoundBullet(float volume = 1f, bool loop = false)
    {
        // 检查音效是否为空
        if (bullet == null)
        {
            Debug.LogWarning("Trying to play null audio clip.");
            return;
        }

        // 设置音量和循环状态
        soundEffectAudioSource.volume = volume;
        soundEffectAudioSource.loop = loop;

        // 播放音效
        soundEffectAudioSource.clip = bullet;
        soundEffectAudioSource.Play();
    }
    public void PlaySoundElbow(float volume = 1f, bool loop = false)
    {
        // 检查音效是否为空
        if (elbow == null)
        {
            Debug.LogWarning("Trying to play null audio clip.");
            return;
        }

        // 设置音量和循环状态
        soundEffectAudioSource.volume = volume;
        soundEffectAudioSource.loop = loop;

        // 播放音效
        soundEffectAudioSource.clip = elbow;
        soundEffectAudioSource.Play();
    }
    public void PlaySoundCxk(float volume = 1f, bool loop = false)
    {
        // 检查音效是否为空
        if (cxk == null)
        {
            Debug.LogWarning("Trying to play null audio clip.");
            return;
        }

        // 设置音量和循环状态
        soundEffectAudioSource.volume = volume;
        soundEffectAudioSource.loop = loop;

        // 播放音效
        soundEffectAudioSource.clip = cxk;
        soundEffectAudioSource.Play();
    }
    public void PlaySoundJump(float volume = 1f, bool loop = false)
    {
        // 检查音效是否为空
        if (jump == null)
        {
            Debug.LogWarning("Trying to play null audio clip.");
            return;
        }

        // 设置音量和循环状态
        soundEffectAudioSource.volume = volume;
        soundEffectAudioSource.loop = loop;

        // 播放音效
        soundEffectAudioSource.clip = jump;
        soundEffectAudioSource.Play();
    }
    // 停止播放音效
    public void StopSound()
        {
            soundEffectAudioSource.Stop();
        }
}
