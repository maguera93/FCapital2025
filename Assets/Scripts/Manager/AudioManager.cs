using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;

    public void PlayAudio(int index, float volume, float pitch)
    {
        GameObject audio = new GameObject();
        AudioSource source = audio.AddComponent<AudioSource>();
        source.clip = clips[index];
        source.volume = volume;
        source.pitch = pitch;

        source.Play();

        Destroy(audio, clips[index].length);
    }
}
