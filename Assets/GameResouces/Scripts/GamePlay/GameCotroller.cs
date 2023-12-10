using UnityEngine;
using UnityEngine.UI;

public class GameCotroller : MonoBehaviour
{
    [SerializeField]
    private Button _completleButton;
    [SerializeField]
    private GameView _gameView;

    private int _level;

    public void Init(int level)
    {
        _level = level;
        _gameView.UpdateLevelView(_level);
        _completleButton.onClick.AddListener(CompleteLevel);
    }

    private void CompleteLevel()
    {
        GameManager.Instance.Level = _level;
        gameObject.SetActive(false);
    }
}
