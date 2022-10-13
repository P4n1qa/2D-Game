using System;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Spirit : MonoBehaviour , IEnemy , IObjectTouch
{
    [SerializeField] private float _speed;

    private WaveContoller _waveContoller;
    private CounterProgress _counterProgress;
    
    private bool isStarted;

    private void Awake()
    {
        _counterProgress = FindObjectOfType<CounterProgress>().GetComponent<CounterProgress>();
        _waveContoller = FindObjectOfType<WaveContoller>().GetComponent<WaveContoller>();
    }

    private void OnEnable()
    {
        _waveContoller.CountEnemyOnScene += 1;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<IBlocker>() != null)
        {
            DeathEnemy();
        }
    }

    public void OnMouseDown()
    {
        DeathEnemy();
    }
    
    public void StartEnemy()
    {
        isStarted = true;
        Move();
    }

    private async void Move()
    {
        while (isStarted) 
        {
            transform.position += new Vector3(0f,  _speed,0f) * Time.deltaTime;
            await Task.Yield();
        }
    }

    private void DeathEnemy()
    {
        isStarted = false;
        _counterProgress.AddScore();
        gameObject.SetActive(false);
    }
    
    private void OnDisable()
    { 
        _waveContoller.CountEnemyOnScene -= 1;
    }
}
