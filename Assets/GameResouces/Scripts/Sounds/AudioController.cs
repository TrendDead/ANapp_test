using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    public const string MUSIC_KEY = "Music";
    public const string SFX_KEY = "Sfx";

    public bool IsMusicOn => PlayerPrefs.GetFloat(MUSIC_KEY, 1) == 1;
    public bool IsSfxOn => PlayerPrefs.GetFloat(SFX_KEY, 1) == 1;

    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private AudioSource _music;
    [SerializeField]
    private AudioSource _clickSound;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadSoundSettings();
    }

    private void LoadSoundSettings()
    {
        _audioMixer.SetFloat(MUSIC_KEY, Mathf.Log10(PlayerPrefs.GetFloat(MUSIC_KEY, 1)) * 20);
        _audioMixer.SetFloat(SFX_KEY, Mathf.Log10(PlayerPrefs.GetFloat(SFX_KEY, 1)) * 20);
    }

    public void ChangeSfxSettins()
    {
        float vol = PlayerPrefs.GetFloat(SFX_KEY, 1) == 1 ? 0.0001f : 1;
        PlayerPrefs.SetFloat(SFX_KEY, vol);
        _audioMixer.SetFloat(SFX_KEY, Mathf.Log10(vol) * 20);
    }


    public void ChangeMusicSettins()
    {
        float vol = PlayerPrefs.GetFloat(MUSIC_KEY, 1) == 1 ? 0.0001f : 1;
        PlayerPrefs.SetFloat(MUSIC_KEY, vol);
        _audioMixer.SetFloat(MUSIC_KEY, Mathf.Log10(vol) * 20);
    }

    public void PlayClickSound()
    {
        _clickSound.Play();
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
