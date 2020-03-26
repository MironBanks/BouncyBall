
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float smooth;
    public float jumpForce;
    public float gravityAcceleration;
    public float maxGravity;

    private Vector3 m_TargetPosition;
    private float m_DownwardVelocity;


    #region Unity Function
    private void Start()
    {
        m_TargetPosition = transform.position;
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
        if (Input.GetMouseButtonUp(0))
        {
            m_TargetPosition.y = transform.position.y + jumpForce;
            m_DownwardVelocity = 0;
        }
    }

    private void Fall()
    {
        m_DownwardVelocity += gravityAcceleration;
        m_DownwardVelocity = Mathf.Clamp(m_DownwardVelocity, 0, maxGravity);
        m_TargetPosition.y -= m_DownwardVelocity * Time.deltaTime;
        if (m_TargetPosition.y < -4)
        {
            m_TargetPosition.y = -4;
        }
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, m_TargetPosition, smooth * Time.deltaTime);
    }
    #endregion
}
