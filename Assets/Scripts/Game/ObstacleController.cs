using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Transform gameMap;
    public GameObject[] obstacles;
    public float interval = 5.0F;

    private List<GameObject> m_Obstacles;

    #region Unity Function
    private void Awake()
    {
        m_Obstacles = new List<GameObject>();
    }
    #endregion

    #region Public Function
    public void AddObstacle(int _progress) { }

    public void Reset()
    {

    }
    #endregion

    #region Private Function
    private GameObject GetRandomObstacle()
    {
        if (obstacles.Length == 0)
        {
            Debug.LogWarning("Trying to get a random obstacle, but no obstacles were found.");
        }
    }
    #endregion
}
