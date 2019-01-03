using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{

    public static SoundSystem instance;

    public AudioClip CoinFX;
    public AudioClip FlyFX;
    public AudioClip DieFX;


    public AudioSource audioSource;


    void Awake() {
        if (SoundSystem.instance == null)
        {
            SoundSystem.instance = this;
        }
        else if (SoundSystem.instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("AudioSystem ha sido instanciado por segunda vez. Eso no debe pasar");

        }
    }


    public void PlayCoin() {

        audioClip(CoinFX);
    
    }

    public void PlayFly(){

        audioClip(FlyFX);
       
    }

    public void PlayDie(){

        audioClip(DieFX);
    }

    private void audioClip(AudioClip audioClip) {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void OnDestroy() { 
        if (SoundSystem.instance == this)
        {
            SoundSystem.instance = null;
        }
    }
}
