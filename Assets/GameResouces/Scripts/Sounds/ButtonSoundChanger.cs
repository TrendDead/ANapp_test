using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundChanger : ButtonClickSound
{
    [SerializeField]
    private Sounds _sound;

    private Image _image;

    enum Sounds
    {
        Sfx,
        Music
    }

    protected override void Awake()
    {
        base.Awake();
        _image = GetComponent<Image>();
        _button.onClick.AddListener(ChangeSound);
        ChangeView();
    }

    private void ChangeSound()
    {
        switch (_sound)
        {
            case Sounds.Sfx:
                AudioController.Instance.ChangeSfxSettins();
                break;
            case Sounds.Music:
                AudioController.Instance.ChangeMusicSettins();
                break;
            default:
                break;
        }

        ChangeView();
    }

    private void ChangeView()
    {
        switch (_sound)
        {
            case Sounds.Sfx:
                _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, AudioController.Instance.IsSfxOn ? 1 : 0.5f);
                break;
            case Sounds.Music:
                _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, AudioController.Instance.IsMusicOn ? 1 : 0.5f);
                break;
            default:
                break;
        }
    }

}
