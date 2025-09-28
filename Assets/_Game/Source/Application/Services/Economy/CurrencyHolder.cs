using UniRx;

namespace _Game.Source.Application.Services.Economy
{
    public class CurrencyHolder
    {
        public ReactiveProperty<Currency> CurrencyProperty { get; }
        
        public CurrencyHolder(Currency currency)
        {
            CurrencyProperty = new ReactiveProperty<Currency>(currency);
        }

        public void AddCoins(int coinsAmount)
        {
            CurrencyProperty.Value += new Currency(){Coins = coinsAmount};
        }

        public void SubCoins(int coinsAmount)
        {
            AddCoins(-coinsAmount);
        }
    }
}