using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSoundChanger : MonoBehaviour
{
    [SerializeField]
    private Sounds _sound;

    private Button _button;
    private Image _image;

    enum Sounds
    {
        Sfx,
        Music
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _button.onClick.AddListener(ChangeSound);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(ChangeSound);
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
