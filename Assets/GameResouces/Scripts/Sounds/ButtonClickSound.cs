using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickSound : MonoBehaviour
{
    protected Button _button;

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(PlaySound);
    }

    protected virtual void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }


    private void PlaySound() => AudioController.Instance.PlayClickSound();
}
