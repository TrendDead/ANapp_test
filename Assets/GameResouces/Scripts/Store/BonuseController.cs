using System;
using System.Collections;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class BonuseController : MonoBehaviour
{
    private const string DAY_KEY = "day";
    private const string LAST_DAY_KEY = "lastDay";

    public int CurrentDay
    {
        get
        {
            return PlayerPrefs.GetInt(DAY_KEY, 0);
        }
        set
        {
            PlayerPrefs.SetInt(DAY_KEY, value);
        }
    }

    private DateTime? LastDay
    {
        get
        {
            string data = PlayerPrefs.GetString(LAST_DAY_KEY, null);

            if (!string.IsNullOrEmpty(data))
            {
                return DateTime.Parse(data);
            }

            return null;
        }
        set
        {
            PlayerPrefs.SetString(LAST_DAY_KEY, value.ToString());
        }
    }

    [SerializeField]
    private BonusePanel[] _panels;
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private Text _sliderText;
    [SerializeField]
    private GameObject _day7Panel;

    private int _maxDay = 7;
    //private float _timeCooldown = 0.0007f;
    private float _timeCooldown = 24f;

    private void OnEnable()
    {
        if (CurrentDay + 1 == _maxDay && ReceiveBonusToday())
        {
            _day7Panel.SetActive(true);
            GetBonuse(5);
            gameObject.SetActive(false);
        }
        else
        {
            CheckingBonus();
        }
    }

    private void CheckingBonus()
    {
        int day = CurrentDay + 1;
        bool isCanReward = ReceiveBonusToday();

        _slider.value = ((float)(day - 1) / 7f);
        _sliderText.text = $"{day - 1}/7";

        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].Init(i + 1, day, isCanReward);
            if (i + 1 == day && isCanReward)
            {
                _panels[i].GetBonuse += GetBonuse;
            }
        }

    }

    private bool ReceiveBonusToday()
    {
        bool isCanBonuse = true;

        if (LastDay.HasValue)
        {
            var timeSpan = DateTime.UtcNow - LastDay.Value;

            if (timeSpan.TotalHours <= _timeCooldown)
            {
                isCanBonuse = false;
            }
        }

        return isCanBonuse;
    }

    private void GetBonuse(int ticket)
    {
        GameManager.Instance.Tickets += ticket;
        if (CurrentDay + 1 < _maxDay)
            _panels[CurrentDay].GetBonuse -= GetBonuse;

        CurrentDay = (CurrentDay + 1) % _maxDay;
        LastDay = DateTime.UtcNow;

        CheckingBonus();
    }

}
