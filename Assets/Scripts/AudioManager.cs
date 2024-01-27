using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioSource bgm;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { 
            DontDestroyOnLoad(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playBGM() { 
    
    }
    public void stopBGM() { 
    
    }
}
