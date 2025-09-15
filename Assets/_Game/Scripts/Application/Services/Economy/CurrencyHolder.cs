using System;

namespace _Game.Scripts.Application.Services.Economy
{
    public class CurrencyHolder
    {
        private readonly Currency _currency;
        public event Action<Currency> CurrencyChanged;

        public CurrencyHolder(Currency currency)
        {
            _currency = currency;
        }

        public void AddCoins(int coinsAmount)
        {
            _currency.Coins += coinsAmount;
            CurrencyChanged?.Invoke(_currency);
        }
    }
}