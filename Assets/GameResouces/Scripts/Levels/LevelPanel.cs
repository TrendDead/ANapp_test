using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : ButtonClickSound
{
    [SerializeField]
    private Text _levelNumber;
    [SerializeField]
    private Image _levelLock;
    [SerializeField]
    private GameCotroller _gameCotroller;

    private int _level;

    public void Init(int level, bool isLock)
    {
        _level = level;
        _levelNumber.text = level.ToString();
        _levelLock.gameObject.SetActive(isLock);
        _levelNumber.gameObject.SetActive(!isLock);
        if (!isLock) _button.onClick.AddListener(OpenLevel);
    }

    private void OpenLevel()
    {
        _gameCotroller.gameObject.SetActive(true);
        _gameCotroller.Init(_level);
    }
}
