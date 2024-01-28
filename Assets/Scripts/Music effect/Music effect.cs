using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Musiceffect : MonoSingleton<Musiceffect>
{
        public static Musiceffect instance; // ����

    public AudioSource soundEffectAudioSource; // ���ڲ�����Ч�� AudioSource ���
    public AudioClip shit;
    public AudioClip jump;
    public AudioClip cxk;
    public AudioClip elbow;
    public AudioClip bullet;
    private void Awake()
        {
            // ���õ���
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            // ȷ����Ч���������ᱻ����
            DontDestroyOnLoad(gameObject);
        }

    // ������Ч
    public void PlaySoundShit( float volume = 1f, bool loop = false)
        {
            // �����Ч�Ƿ�Ϊ��
            if (shit == null)
            {
                Debug.LogWarning("Trying to play null audio clip.");
                return;
            }

            // ����������ѭ��״̬
            soundEffectAudioSource.volume = volume;
            soundEffectAudioSource.loop = loop;

            // ������Ч
            soundEffectAudioSource.clip = shit;
            soundEffectAudioSource.Play();
        }
    public void PlaySoundBullet(float volume = 1f, bool loop = false)
    {
        // �����Ч�Ƿ�Ϊ��
        if (bullet == null)
        {
            Debug.LogWarning("Trying to play null audio clip.");
            return;
        }

        // ����������ѭ��״̬
        soundEffectAudioSource.volume = volume;
        soundEffectAudioSource.loop = loop;

        // ������Ч
        soundEffectAudioSource.clip = bullet;
        soundEffectAudioSource.Play();
    }
    public void PlaySoundElbow(float volume = 1f, bool loop = false)
    {
        // �����Ч�Ƿ�Ϊ��
        if (elbow == null)
        {
            Debug.LogWarning("Trying to play null audio clip.");
            return;
        }

        // ����������ѭ��״̬
        soundEffectAudioSource.volume = volume;
        soundEffectAudioSource.loop = loop;

        // ������Ч
        soundEffectAudioSource.clip = elbow;
        soundEffectAudioSource.Play();
    }
    public void PlaySoundCxk(float volume = 1f, bool loop = false)
    {
        // �����Ч�Ƿ�Ϊ��
        if (cxk == null)
        {
            Debug.LogWarning("Trying to play null audio clip.");
            return;
        }

        // ����������ѭ��״̬
        soundEffectAudioSource.volume = volume;
        soundEffectAudioSource.loop = loop;

        // ������Ч
        soundEffectAudioSource.clip = cxk;
        soundEffectAudioSource.Play();
    }
    public void PlaySoundJump(float volume = 1f, bool loop = false)
    {
        // �����Ч�Ƿ�Ϊ��
        if (jump == null)
        {
            Debug.LogWarning("Trying to play null audio clip.");
            return;
        }

        // ����������ѭ��״̬
        soundEffectAudioSource.volume = volume;
        soundEffectAudioSource.loop = loop;

        // ������Ч
        soundEffectAudioSource.clip = jump;
        soundEffectAudioSource.Play();
    }
    // ֹͣ������Ч
    public void StopSound()
        {
            soundEffectAudioSource.Stop();
        }
}
