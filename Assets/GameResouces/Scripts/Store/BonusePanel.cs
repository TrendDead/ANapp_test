using System;
using UnityEngine;
using UnityEngine.UI;

public class BonusePanel : ButtonClickSound
{
    public event Action<int> GetBonuse;

    [SerializeField]
    private Image _background;
    [SerializeField]
    private Text _bonusText;
    [SerializeField]
    private Text _dayText;

    [SerializeField]
    private int _bonusTickets;

    private CanvasGroup _canvasGroup;
    private int _indexDay;


    public void Init(int day, int today, bool isCanGet)
    {
        _button = _button == null ? GetComponent<Button>() : _button;
        _canvasGroup = GetComponent<CanvasGroup>();
        _indexDay = day;
        _dayText.text = $"DAY{day}";
        _bonusText.text = $"X{_bonusTickets}";
        BonuseView(_indexDay.CompareTo(today), isCanGet);
    }

    private void BonuseView(int compare, bool isCanGet)
    {
        if (compare == -1) 
        { 
            _button.enabled = false;
            _background.color = Color.green;
        }
        else if (compare == 1 || (compare == 0 && !isCanGet))
        {
            _canvasGroup.alpha = 0.5f;
            _button.enabled = false;
            _background.color = Color.white;
        }
        else if(isCanGet)
        {
            _canvasGroup.alpha = 1f;
            _button.enabled = true;
            _button.onClick.AddListener(BonuseGeter);
        }
    }

    private void BonuseGeter()
    {
        GetBonuse?.Invoke(_bonusTickets);
    }
}
