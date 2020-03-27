
using UnityEngine;
using UnityCore.Session;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public CameraController camera;
    public ObstacleController obstacles;

    private SessionController m_Session;
    private int m_Progress = -1;

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
        obstacles.AddObstacle(m_Progress);
    }

    public void OnUpdate()
    {
        player.OnUpdate();
        camera.OnUpdate();
        CheckPlayerProgress();
    }

    #endregion

    #region Private Function

    private void CheckPlayerProgress()
    {
        if (player.transform.position.y / obstacles.interval > (m_Progress + 1))
        {
            m_Progress++;
            obstacles.AddObstacle(m_Progress);
        }
    }


    #endregion
}
