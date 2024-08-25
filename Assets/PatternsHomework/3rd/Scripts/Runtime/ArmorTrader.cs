using UnityEngine;

namespace ThirdTask
{
    public class ArmorTrader : Trader
    {
        protected override void Trade()
        {
            Debug.Log("You can buy ARMOR from me!");
        }
    }
}