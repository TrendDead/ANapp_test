using UnityEngine;

public class LevelsController : MonoBehaviour
{
    [SerializeField]
    private LevelPanel[] _levels;

    private void Start()
    {
        LevelsInfoUpdate();
        GameManager.Instance.LevelsUpdate += LevelsInfoUpdate;
    }

    private void OnDestroy()
    {
        GameManager.Instance.LevelsUpdate -= LevelsInfoUpdate;
    }

    private void LevelsInfoUpdate()
    {
        int lastLevel = GameManager.Instance.Level;

        for (int i = 0; i < _levels.Length; i++)
        {
            _levels[i].Init(i + 1, i <= lastLevel ? false : true);
        }
    }
}
