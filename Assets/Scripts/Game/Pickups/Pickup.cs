
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private GameController m_Game;
    private bool m_DidCollect;


    protected GameController game
    {
        get
        {
            if (!m_Game)
            {
                m_Game = GameController.instance;
            }
            if (!m_Game)
            {
                Debug.LogWarning("Your pickup is trying to access the game, but no instance of GameControll was founded");
            }
            return m_Game;
        }
    }

    #region Unity Function

    #endregion
}
