using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource backgroundMusicSource;
    private AudioSource[] soundEffectSources;

    [SerializeField] private AudioClip scoreSoundClip; // Reference to the score sound clip

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        backgroundMusicSource = GetComponent<AudioSource>(); // Assuming you have one AudioSource for music
        soundEffectSources = GetComponents<AudioSource>(); // Assuming additional AudioSources for sound effects
    }

    public void SetSoundEffectsVolume(float volume)
    {
        foreach (var source in soundEffectSources)
        {
            source.volume = volume;
        }
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicSource.volume = volume;
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        foreach (var source in soundEffectSources)
        {
            if (!source.isPlaying)
            {
                source.clip = clip;
                source.Play();
                break;
            }
        }
    }

    public void PlayScoreSound()
    {
        PlaySoundEffect(scoreSoundClip); // Play the score sound
    }
}
