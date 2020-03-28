
using UnityEngine;

public class InvincibilityPickup : Pickup
{

    public float duration;


    #region Override Function
    protected override void OnPlayerCollect()
    {
        base.OnPlayerCollect();
        game.HandleInvincibilityPickup(duration);
    }
    #endregion
}
