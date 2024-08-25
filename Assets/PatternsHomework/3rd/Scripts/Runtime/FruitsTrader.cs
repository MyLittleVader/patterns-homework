using UnityEngine;

namespace ThirdTask
{
    public class FruitsTrader : Trader
    {
        protected override void Trade()
        {
            Debug.Log("You can buy FRUITS from me!");
        }
    }
}