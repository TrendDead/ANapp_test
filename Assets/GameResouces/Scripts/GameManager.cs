using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action<int> TicketsUpdate;

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
