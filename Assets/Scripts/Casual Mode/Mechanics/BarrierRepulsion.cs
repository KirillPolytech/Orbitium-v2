using UnityEngine;

public class BarrierRepulsion : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody _rb;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player)
            _rb = _player.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_rb)
            {
                _rb.velocity += collision.GetContact(0).normal * 100;
                Debug.Log("YES");
            }
        }
    }
}
