using UnityEngine;
using UnityEngine.UI;

public class InternalPurchasePanel : ButtonClickSound
{
    [SerializeField]
    private GameObject _canBuyView;
    [SerializeField]
    private GameObject _cantBuyView;
    [SerializeField]
    private Text _nameText;
    [SerializeField]
    private Text _priceText;
    [SerializeField]
    private Text _lvelToBuyText;
    [SerializeField]
    private GameObject _ticketsView;
    [SerializeField]
    private GameObject _isBuyView;

    [Header("Parameters")]
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _price;
    [SerializeField]
    private int _levelToBuy;
    [SerializeField]
    private bool _isBuy = false;
    

    protected override void Awake()
    {
        base.Awake();
        _lvelToBuyText.text = $"LV.{_levelToBuy}";
        _nameText.text = _name;
        _priceText.text = _price.ToString();
        if (!_isBuy) _isBuy = PlayerPrefs.GetInt(_name, 0) == 1;
    }

    private void OnEnable()
    {
        CheckingPossibilityPurchase();
    }


    private void CheckingPossibilityPurchase()
    {
        if (!_isBuy)
        {
            _ticketsView.SetActive(true);
            _isBuyView.SetActive(false);

            if (_levelToBuy <= GameManager.Instance.Level) 
            {
                _button.enabled = true;
                _cantBuyView.SetActive(false);
                _canBuyView.SetActive(true);
                _button.onClick.AddListener(Buy);
            }
            else
            {
                _button.enabled = false;
                _cantBuyView.SetActive(true);
                _canBuyView.SetActive(false);
            }
        }
        else
        {
            _button.enabled = false;
            _cantBuyView.SetActive(false);
            _canBuyView.SetActive(true);
            _ticketsView.SetActive(false);
            _isBuyView.SetActive(true);
        }
    }

    private void Buy()
    {
        if (GameManager.Instance.Tickets >= _price)
        {
            _isBuy = true;
            GameManager.Instance.Tickets -= _price;
            PlayerPrefs.SetInt(_name, 1);
            CheckingPossibilityPurchase();
        }
    }
         
}
