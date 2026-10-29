using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum BackgroundMusic
{
    Home,
    Normal
}

public enum SFXMusic
{
    Catch
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    [Header("Audio Sources")]
    public AudioSource backgroundSource;
    public AudioSource sfxSource;

    [Header("Audio Mixer")]
    public AudioMixer audioMixer;

    [Header("Background Clips")]
    public AudioClip backgroundClip;

    [Header("SFX Clips")]
    public AudioClip winClip;
    public AudioClip loseClip;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PlayMusic(backgroundClip);
        LoadAudioSettings();
    }
    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            backgroundSource.clip = clip;
            backgroundSource.loop = true;
            backgroundSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void WinSFX()
    {
        PlaySFX(winClip);
    }

    public void LoseSFX()
    {
        PlaySFX(loseClip);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("BackgroundVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }

    public void LoadAudioSettings()
    {
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        SetVolume(masterVolume);
        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
    }
}
