using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Musiceffect : MonoSingleton<Musiceffect>
{
    public AudioClip soundEffect; // ��Ч�ļ�
    private AudioSource audioSource;

    private void Start()
    {
        // ��ȡ AudioSource ���
        audioSource = GetComponent<AudioSource>();

        // ������Ч�ļ��� AudioSource ���
        audioSource.clip = soundEffect;
    }
    public void PlaySoundEffect()
    {
        // ��� AudioSource ����Ƿ�����Լ���Ч�ļ��Ƿ����
        if (audioSource != null && audioSource.clip != null)
        {
            // ������Ч
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource component or sound effect is missing.");
        }
    }
    
}
