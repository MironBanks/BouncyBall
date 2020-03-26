
using UnityEngine;
using UnityCore.Session;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public CameraController camera;
    private SessionController m_Session;

    private SessionController session
    {
        get
        {
            if (!m_Session)
            {
                m_Session = SessionController.instance;
            }
            if (!m_Session)
            {
                Debug.LogWarning("Game is trying to access the session, but no instance od SessionController was found.");
            }
            return m_Session;
        }
    }

    #region Unity Function

    private void Start()
    {
        if (!session) return;
        session.InitializeGame(this);
    }

    #endregion

    #region Public Function

    public void OnInit()
    {
        player.OnInit();
        camera.OnInit();
    }

    public void OnUpdate()
    {
        player.OnUpdate();
        camera.OnUpdate();
    }

    #endregion

    #region Private Function




    #endregion
}
