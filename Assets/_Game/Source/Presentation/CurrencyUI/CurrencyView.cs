using _Game.Source.Application.Services.Economy;
using TMPro;
using UnityEngine;

namespace _Game.Source.Presentation.CurrencyUI
{
    public class CurrencyView: MonoBehaviour, IView<CurrencyViewData>
    {
        [SerializeField] private TextMeshProUGUI _currencyTextUI;
        public void SetData(CurrencyViewData data)
        {
            _currencyTextUI.text = data.Currency.Coins.ToString();
        }
    }

    public struct CurrencyViewData
    {
        public Currency Currency { get; }

        public CurrencyViewData(Currency currency)
        {
            Currency = currency;
        }
    }
}