using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TicketView : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        UpdateView(GameManager.Instance.Tickets);
        GameManager.Instance.TicketsUpdate += UpdateView;
    }

    private void OnDestroy()
    {
        GameManager.Instance.TicketsUpdate -= UpdateView;
    }

    private void UpdateView(int ticket)
    {
        _text.text = ticket.ToString();
    }
}
