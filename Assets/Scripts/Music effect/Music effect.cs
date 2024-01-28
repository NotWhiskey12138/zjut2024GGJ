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
