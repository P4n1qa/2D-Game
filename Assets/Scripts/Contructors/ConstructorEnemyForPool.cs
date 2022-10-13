using UnityEngine;

public static class ConstructorEnemyForPool 
{
    public static Spirit CreateSpirit (PoolMono<Spirit> poolSpirit , Transform spawn)
    {
        var enemy = poolSpirit.GetFreeElement();
        
        enemy.transform.position = spawn.position;
        return enemy;
    }
}
