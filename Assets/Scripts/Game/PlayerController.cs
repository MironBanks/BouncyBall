
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float smooth;
    public float jumpForce;
    public float gravityAcceleration;
    public float maxGravity;

    private Vector3 m_TargetPosition;
    private float m_DownwardAcceleration;


    #region Unity Function
    private void Start()
    {

    }

    private void Update()
    {
        Jump();
        Fall();
        Move();
    }
    #endregion

    #region Public Function

    #endregion

    #region Private Function
    private void Jump()
    {

    }

    private void Fall()
    {

    }

    private void Move()
    {

    }
    #endregion
}
