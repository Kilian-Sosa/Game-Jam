using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    public Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> musicClips = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }

        DontDestroyOnLoad(gameObject);

        LoadSFXClips();
        LoadMusicClips();
    }

    private void LoadSFXClips()
    {
        sfxClips["Enemy2Death"] = Resources.Load<AudioClip>("SFX/EyeDeath");
        sfxClips["Enemy2Move"] = Resources.Load<AudioClip>("SFX/EyeMovement");
        sfxClips["PlayerDeath"] = Resources.Load<AudioClip>("SFX/PlayerDeath");
    }

    private void LoadMusicClips()
    {
        musicClips["MainTheme"] = Resources.Load<AudioClip>("Music/MainTheme");
        musicClips["TitleTheme"] = Resources.Load<AudioClip>("Music/TitleTheme");
    }

    public void PlaySFX(string clipName)
    {
        if (sfxClips.ContainsKey(clipName))
        {
            sfxSource.clip = sfxClips[clipName];
            sfxSource.Play();
        }
        else Debug.LogWarning("El AudioClip " + clipName + " no se encontr� en el diccionario de sfxClips.");
    }

    public void PlayMusic(string clipName)
    {
        if (musicClips.ContainsKey(clipName))
        {
            musicSource.clip = musicClips[clipName];
            musicSource.Play();
        }
        else Debug.LogWarning("El AudioClip " + clipName + " no se encontr� en el diccionario de musicClips.");

        musicSource.loop = (clipName == "MainTheme") ? true : false;
    }

}