﻿using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Transform gameMap;
    public GameObject[] obstacles;
    public GameObject[] pickups;
    public float interval = 5.0F;

    private List<GameObject> m_Obstacles;
    private List<GameObject> m_Pickups;

    #region Unity Function
    private void Awake()
    {
        m_Obstacles = new List<GameObject>();
        m_Pickups = new List<GameObject>();
    }
    #endregion

    #region Public Function
    public void AddObstacle(int _progress)
    {
        GameObject _prefab = GetRandomObstacle(obstacles);
        if (!_prefab)
        {
            return;
        }

        GameObject _new = Instantiate(_prefab);
        _new.transform.parent = gameMap;
        float _y = interval * (_progress + 1);
        _new.transform.position = Vector3.up * _y;

        m_Obstacles.Insert(0, _new);

        if (m_Obstacles.Count > 4)
        {
            Destroy(m_Obstacles[m_Obstacles.Count - 1]);
            m_Obstacles.RemoveAt(m_Obstacles.Count - 1);
        }
    }

    public void AddPickup(int _progress)
    {
        GameObject _prefab = GetRandomObstacle(pickups);
        if (!_prefab)
        {
            return;
        }

        GameObject _new = Instantiate(_prefab);
        _new.transform.parent = gameMap;
        float _y = interval * (_progress + 1) + interval * 0.5f;
        _new.transform.position = Vector3.up * _y;

        m_Pickups.Insert(0, _new);

        if (m_Pickups.Count > 4)
        {
            Destroy(m_Pickups[m_Pickups.Count - 1]);
            m_Pickups.RemoveAt(m_Pickups.Count - 1);
        }
    }

    public void Reset()
    {
        for (int i = m_Obstacles.Count - 1; i >= 0; i--)
        {
            if (m_Pickups[i] != null)
            {
                Destroy(m_Obstacles[i]);
            }
            m_Obstacles.RemoveAt(i);
        }

        for (int i = m_Pickups.Count - 1; i >= 0; i--)
        {
            Destroy(m_Pickups[i]);
            m_Pickups.RemoveAt(i);
        }
    }
    #endregion

    #region Private Function
    private GameObject GetRandomObstacle(GameObject[] _arr)
    {
        if (_arr.Length == 0)
        {
            Debug.LogWarning("Trying to get a random obstacle, but no obstacles were found.");
            return null;
        }

        int _random = Random.Range(0, _arr.Length);
        return _arr[_random];
    }
    #endregion
}
