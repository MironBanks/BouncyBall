﻿using System.Collections.Generic;
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
    public void AddObstacle(int _progress)
    {
        GameObject _prefab = GetRandomObstacle();
        if (!_prefab)
        {
            return;
        }

        GameObject _new = Instantiate(_prefab);
        _new.transform.parent = gameMap;
        float _y = interval * (_progress + 1);
        _new.transform.position = Vector3.up * _y;

        m_Obstacles.Add(_new);

        if (m_Obstacles.Count > 4)
        {
            Destroy(m_Obstacles[m_Obstacles.Count - 1]);
            m_Obstacles.RemoveAt(m_Obstacles.Count - 1);
        }
    }

    public void Reset()
    {
        for (int i = m_Obstacles.Count - 1; i >= 0; i--)
        {
            Destroy(m_Obstacles[i]);
            m_Obstacles.RemoveAt(i);
        }
    }
    #endregion

    #region Private Function
    private GameObject GetRandomObstacle()
    {
        if (obstacles.Length == 0)
        {
            Debug.LogWarning("Trying to get a random obstacle, but no obstacles were found.");
            return null;
        }

        int _random = Random.Range(0, obstacles.Length);
        return obstacles[_random];
    }
    #endregion
}
