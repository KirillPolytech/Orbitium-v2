using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private Transform _parent;
    private SurvivorEnemy _survivalEnemy;
    private SurvivorPlayer _survivorPlayer;
    private void Awake()
    {
        _parent = transform.parent;
        if (_parent.GetComponent<SurvivorEnemy>())
        {
            _survivalEnemy = _parent.GetComponent<SurvivorEnemy>();
        }
        else if (_parent.GetComponent<SurvivorPlayer>())
        {
            _survivorPlayer = _parent.GetComponent<SurvivorPlayer>();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if ( other.gameObject.CompareTag("Enemy") )
        {
            if (_parent.transform.localScale.x < other.transform.localScale.x)
            {
                if (_survivalEnemy)
                {
                    _survivalEnemy.Dying();
                    _survivalEnemy.Death();
                }else if (_survivorPlayer)
                {
                    _survivorPlayer.Dying();
                    _survivorPlayer.Death();
                }
            }
            else
            {
                if (_survivalEnemy)
                    _survivalEnemy.EatingOther();
                if (_survivorPlayer)
                    _survivorPlayer.EatingOther();

                other.GetComponent<SurvivorEnemy>().Dying();
                other.GetComponent<SurvivorEnemy>().Death();
            }
        }

        if (other.gameObject.CompareTag("Player"))
        {
            if (_parent.transform.localScale.x < other.gameObject.transform.localScale.x)
            {
                _survivalEnemy.Dying();
                _survivalEnemy.Death();
            }
            else
            {
                _survivalEnemy.EatingOther();
                other.GetComponent<SurvivorPlayer>().Dying();
                other.GetComponent<SurvivorPlayer>().Death();
            }
        }
    }
}
// Если в нас входит объект с тегом Enemy, то сравниваем наши размеры.
// Если мы меньше, то умираем
// Если больше - едим.
/*
if (!other.gameObject.GetComponent<SurvivorPlayer>())
{
    _parent.GetComponent<SurvivorEnemy>().EatingOther(other.gameObject);
    other.gameObject.GetComponent<SurvivorEnemy>().Dying();
}
else
{
    _parent.GetComponent<SurvivorPlayer>().EatingOther(other.gameObject);
    other.GetComponent<SurvivorPlayer>().Dying();
}

else
        {
            _parent.GetComponent<SurvivorEnemy>().EatingOther(other.gameObject);
            other.gameObject.GetComponent<SurvivorEnemy>().Dying();
        }
*/
