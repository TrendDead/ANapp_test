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
    }

}
