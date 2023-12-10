using UnityEngine;
using UnityEngine.Purchasing;

public class Putchaser : MonoBehaviour
{
    public void OnPurcaseComplited(Product product)
    {
        switch (product.definition.id) 
        {
            case "ticket500":
                AddCoins(500);
                break;
            case "ticket1200":
                AddCoins(1200);
                break;
        }
    }

    private void AddCoins(int coins)
    {
        GameManager.Instance.Tickets = GameManager.Instance.Tickets + coins;    
    }
}
