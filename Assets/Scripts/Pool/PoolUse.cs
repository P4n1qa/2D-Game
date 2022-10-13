using UnityEngine;

public class PoolUse : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private int _poolCount;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private Spirit _enemy;

    private PoolMono<Spirit> _poolMonoEnemy;
    
    private void Awake()
    {
        CreatePoolEnemy();
    }

    private void CreatePoolEnemy()
    {
        _poolMonoEnemy = new PoolMono<Spirit>(_enemy, this._poolCount, this.transform);
        _poolMonoEnemy.AutoExpand = _autoExpand;
    }
    
    public void CreateEnemy()
    {
        var enemy = ConstructorEnemyForPool.CreateSpirit(_poolMonoEnemy,_spawn);
        enemy.StartEnemy();
    }
}
