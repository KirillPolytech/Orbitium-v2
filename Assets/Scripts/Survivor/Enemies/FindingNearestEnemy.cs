using UnityEngine;
using System.Collections.Generic;

public class FindingNearestEnemy : MonoBehaviour
{
    private List<GameObject> _enemies = new();
    private float _nearestDistance = float.MaxValue;
    private GameObject _nearestGameObject = null;
    private int Timer = 0;
    private Transform _parent;
    private void Awake()
    {
        _parent = transform.parent;
    }
    private void FixedUpdate()
    {
        GetNearestEnemy();
    }
    public GameObject GetNearestEnemy()
    {
        if (Timer >= 0)
        {
            foreach (var item in _enemies)
            {
                if (item.gameObject != null && item.gameObject != _parent.gameObject)
                {
                    if (_nearestDistance > (item.transform.position - _parent.position).magnitude)
                    {
                        _nearestDistance = (item.transform.position - _parent.position).magnitude;
                        _nearestGameObject = item.gameObject;
                    }
                }
            }
            Timer = 0;
        }
        Timer++;
        return _nearestGameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            _enemies.Add(other.gameObject); 
        }
    }
    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            foreach (var item in _enemies.ToArray())
            {
                if (item.name == other.name)
                    _enemies.Remove(item);
            }
        }
    }
    */
}