using UnityEngine;

namespace ThirdTask
{
    public class EmptyTrader : Trader
    {
        protected override void Trade()
        {
            Debug.Log("I have NOTHING to sell for you. Get lost!");
        }
    }
}