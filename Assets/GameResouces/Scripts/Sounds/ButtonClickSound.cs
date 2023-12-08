using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickSound : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(PlaySound);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(PlaySound);
    }


    private void PlaySound() => AudioController.Instance.PlayClickSound();
}
