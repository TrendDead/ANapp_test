using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField]
    private Text _levelText;

    public void UpdateLevelView(int level)
    {
        _levelText.text = $"Level - {level}";

    }
}
