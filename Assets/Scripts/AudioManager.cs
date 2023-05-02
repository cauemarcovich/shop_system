using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance => _instance;

    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip buySellSound;
    
    private AudioSource _audioSource;
    
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayClick() => _audioSource.PlayOneShot(clickSound);
    public void PlayBuySell() => _audioSource.PlayOneShot(buySellSound);
}
