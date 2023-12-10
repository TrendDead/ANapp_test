using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action<int> TicketsUpdate;
    public event Action LevelsUpdate;

    public int Tickets
    {
        get
        {
            return PlayerPrefs.GetInt("Tickets", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Tickets", value);
            PlayerPrefs.Save();
            TicketsUpdate?.Invoke(value);
        }
    }    
    
    public int Level
    {
        get
        {
            return PlayerPrefs.GetInt("Level", 0);
        }
        set
        {
            if(value > Level)
            {
                PlayerPrefs.SetInt("Level", value);
                PlayerPrefs.Save();
                LevelsUpdate?.Invoke();
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
