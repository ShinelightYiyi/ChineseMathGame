using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMag 
{
    private static AudioMag instance;
    public static AudioMag Instance { get => instance ?? new AudioMag(); }

    public void Play(string Path)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Music");
        AudioSource aui = go.GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>(Path);
        aui.clip = clip;
        aui.Play();
    }

    public void PlayOneShot(string Path)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Sound");
        AudioSource aui = go.GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>(Path);
        aui.clip = clip;
        aui.PlayOneShot(aui.clip);
    }

    public void Stop(string Path)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Music");
        AudioSource aui = go.GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>(Path);
        aui.clip = clip;
        aui.Stop();
    }
}
