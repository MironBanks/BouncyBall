
using UnityEngine;
using UnityCore.Session;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public PlayerController player;
    public CameraController camera;
    public ObstacleController obstacles;
    public int pickupDropRate = 3;

    private SessionController m_Session;
    private int m_Progress = -1;
    private int m_ScoreMultiplier = 1;
    private bool m_Invincible;
    private bool m_DidDropPickup;
    private float m_ScoreMultiplierDuration;
    private float m_InvincibilityDuration;

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

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

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

    public void HandleInvincibilityPickup(float _duration)
    {
        m_InvincibilityDuration = _duration;
        m_Invincible = true;

        m_ScoreMultiplier = 1;
        m_ScoreMultiplierDuration = 0;
    }

    public void HandleScorePickup(int _multiplier, float _duration)
    {
        m_ScoreMultiplier = _multiplier;
        m_ScoreMultiplierDuration = _duration;

        m_Invincible = false;
        m_InvincibilityDuration = 0;
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

        if (m_Progress > 0 && m_Progress % pickupDropRate == 0)
        {
            if (!m_DidDropPickup)
            {
                m_DidDropPickup = true;
                obstacles.AddPickup(m_Progress);
            }
        }
        else
        {
            m_DidDropPickup = false;
        }
    }


    #endregion
}
