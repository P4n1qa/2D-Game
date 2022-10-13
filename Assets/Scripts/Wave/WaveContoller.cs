using System.Threading.Tasks;
using UnityEngine;

public class WaveContoller : MonoBehaviour
{
    [SerializeField] private PoolUse _poolUse;
    [SerializeField] private int _countMaxEnemy;

    private bool canLoadWave;
    
    [HideInInspector] public int CountEnemyOnScene;
    private bool CountEnemyIsSmall()
    {
        return _countMaxEnemy > CountEnemyOnScene;
    }

    private void Start()
    {
        canLoadWave = true;
        LoadWave();
    }

    private async void LoadWave()
    {
        while (canLoadWave)
        {
            if (CountEnemyIsSmall())
            {
                _poolUse.CreateEnemy();
                await Task.Delay(1000);
            }
            else
            {
                await Task.Delay(1000);
            }
        }
    }
}
