
using UnityEngine;

public class ScorePickup : Pickup
{

    public float duration;
    public int multiplier;


    #region Override Function
    protected override void OnPlayerCollect()
    {
        base.OnPlayerCollect();
        game.HandleScorePickup(multiplier, duration);
    }
    #endregion
}
