using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public enum MusicIDs
    {
        MainMenuTheme,
        LevelOneDNB,
    }

    public enum SceneIndices
    {
        MainMenu,
        Level1,
        SceneIndexCount
    }

    public enum AudioSourceIDs
    {
        Music,
        UI,
        AudioSourceCount
    }

    AudioSource[] audioSources;

    [HideInInspector]
    // Singleton instance of AudioManager
    // Can be accessed from any script
    public static AudioManager instance = null;

    // User volume values
    [Range(0f, 1f)]
    public float masterVolume = 1f;

    [Range(0f, 1f)]
    public float uiVolume = 1f;

    [Range(0f, 1f)]
    public float musicVolume = 1f;

    // Audio Clips
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip uiButtonHighlighted;
    public AudioClip uiButtonPressed;

    void Awake ()
    {
        // Check for already existing instances of AudioManager
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Keep audio manager between scenes
        DontDestroyOnLoad(gameObject);

        // Init audio sources
        InitializeAudioSources();
    }

    void Start ()
    {
        // Set initial music to be MainMum
        GetAudioSource(AudioSourceIDs.Music).clip = menuMusic;

        PlayMusic();
        UpdateVolumes();
    }
    
    void InitializeAudioSources ()
    {
        audioSources = new AudioSource[(int) AudioSourceIDs.AudioSourceCount];

        for (int i = 0; i < (int) AudioSourceIDs.AudioSourceCount; i++)
        {
            AudioSource _audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
            
            // Enable playOnWake & looping for music AudioSource
            if (i == (int) AudioSourceIDs.Music)
            {
                _audioSource.playOnAwake = true;
                _audioSource.loop = true;
            }

            audioSources[i] = _audioSource;
        }
    }

    public AudioSource GetAudioSource (AudioSourceIDs type)
    {
        return audioSources[(int) type];
    }

    void UpdateVolumes ()
    {
        GetAudioSource(AudioSourceIDs.Music).volume = masterVolume * musicVolume;
        GetAudioSource(AudioSourceIDs.UI).volume = masterVolume * uiVolume;
    }

    public void SetMusicClip (MusicIDs musicID)
    {
        switch (musicID)
        {
            case MusicIDs.MainMenuTheme:
                GetAudioSource(AudioSourceIDs.Music).clip = menuMusic;
                break;

            case MusicIDs.LevelOneDNB:
                GetAudioSource(AudioSourceIDs.Music).clip = gameMusic;
                break;

            default:
                Debug.Log("Song index not found.");
                break;
        }
    }

    public void PlayMusic ()
    {
        GetAudioSource(AudioSourceIDs.Music).Play();
    }

    void Update ()
    {
        // Update volumes if changed
        UpdateVolumes();

        // Listen to SceneLoaded event
        SceneManager.activeSceneChanged += onSwapMusic;
    }

    #region Helper Functions

    void onSwapMusic (Scene prevScene, Scene nextScene)
    {
        SetMusicClip((MusicIDs)nextScene.buildIndex);

        PlayMusic();
    }

    #endregion
}