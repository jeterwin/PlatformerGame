using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public static SettingsScript Instance;
    [Header("Volume variables")]
    [SerializeField] private AudioMixer MainAudioMixer;
    [SerializeField] private Slider MainVolumeSlider, SFXVolumeSlider;

    #region volume
    private float MainVolume
    {
        get  { return PlayerPrefs.HasKey("MainVolume") ? PlayerPrefs.GetFloat("MainVolume") == 0.001f ? -80f : PlayerPrefs.GetFloat("MainVolume") : 1f; }
        set { PlayerPrefs.SetFloat("MainVolume", value); }
    }
    private float SFXVolume
    {
        get { return PlayerPrefs.HasKey("SFXVolume") ? PlayerPrefs.GetFloat("SFXVolume") == 0.001f ? -80f : PlayerPrefs.GetFloat("SFXVolume") : 1f; }
        set { PlayerPrefs.SetFloat("SFXVolume", value); }
    }

    public int CurrentLevel
    {
        get { return PlayerPrefs.HasKey("CurrentLevel") ? PlayerPrefs.GetInt("CurrentLevel") : 1; }
        set { PlayerPrefs.SetInt("CurrentLevel", value); }
    }

    public void SetMainVolume(float volume)
    {
        MainVolume = volume;
        MainAudioMixer.SetFloat("MainVolume", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        SFXVolume = volume;
        MainAudioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
    #endregion

    public void SetCurrentLevel(int LevelID)
    {
        CurrentLevel = LevelID;
    }

    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        MainVolumeSlider.value = MainVolume;
        SFXVolumeSlider.value = SFXVolume;
        MainAudioMixer.SetFloat("MainVolume", Mathf.Log10(PlayerPrefs.GetFloat("MainVolume")) * 20);
        MainAudioMixer.SetFloat("SFXVolume", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume")) * 20);
    }
    
}
