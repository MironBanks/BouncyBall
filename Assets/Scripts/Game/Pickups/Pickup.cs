
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
    private void OnTriggerEnter2D(Collider2D _col)
    {
        if (!game) return;
        if (m_DidCollect) return;
        if (_col.gameObject.tag.Equals("Player"))
        {
            m_DidCollect = true;
            OnPlayerCollect();
            Destroy(gameObject);
        }
    }
    #endregion

    #region Override Function
    protected virtual void OnPlayerCollect()
    {
        Debug.Log("Player picket up [" + gameObject.name"].");
    }
    #endregion
}
