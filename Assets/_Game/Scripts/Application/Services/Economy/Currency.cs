namespace _Game.Scripts.Application.Services.Economy
{
    public struct Currency
    {
        public int Coins { get; set; }

        public static Currency operator +(Currency x, Currency y)
        {
            return new Currency { Coins = x.Coins + y.Coins };
        }
    }
}