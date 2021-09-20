using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierGenerator : MonoBehaviour
{
    [SerializeField] private int _coinsCount;
    [SerializeField] private float _coinsHeight;
    [SerializeField] private int _itemSpeace;

    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private List<GameObject> _pool;

    private enum CoinStyle
    {
        Line,
        Jump
    }

    private void Start()
    {
        SpawnBarrier();    
    }

    private void SpawnBarrier()
    {
        int spawnPointNamber = Random.Range(0, _spawnPoints.Length);
        int rand = Random.Range(1, _pool.Count);

        GameObject spawned = Instantiate(_pool[rand], _spawnPoints[spawnPointNamber].position + _pool[rand].transform.position, Quaternion.identity, transform);
        
        CoinStyle coinStyle = CoinStyle.Line;

        if (_spawnPoints[spawnPointNamber].position != null && _pool[rand].transform.position.y < 0.6f)
        {
            coinStyle = CoinStyle.Jump;
            CreateCoin(coinStyle, _spawnPoints[spawnPointNamber].position, _coin);
        }
        else if (_spawnPoints[spawnPointNamber].position != null && _pool[rand].transform.position.y <= 2.5f && _pool[rand].transform.localScale.y > 4)
        {
            if (spawnPointNamber == 0)
            {
                CreateCoin(coinStyle, _spawnPoints[spawnPointNamber + 1].position, _coin);
            }
            else if (spawnPointNamber == 1)
            {
                CreateCoin(coinStyle, _spawnPoints[spawnPointNamber + 1].position, _coin);
            }
            else
            {
                CreateCoin(coinStyle, _spawnPoints[spawnPointNamber - 1].position, _coin);
            }
            
        }
        else if (_spawnPoints[spawnPointNamber].position != null && _pool[rand].transform.position.y <= 2.5f)
        {
            CreateCoin(coinStyle, _spawnPoints[spawnPointNamber].position, _coin);
        }
    }

    private void CreateCoin(CoinStyle style, Vector3 spawn, GameObject prefabCoin)
    {
        Vector3 coinPosition = Vector3.zero;
        if (style == CoinStyle.Line)
        {
            for (int i = -_coinsCount / 2; i < _coinsCount / 2; i++)
            {
                coinPosition.y = _coinsHeight;
                CreateNexCoin(i, coinPosition, spawn, prefabCoin);
            }
        }
        else if (style == CoinStyle.Jump)
        {
            for (int i = -_coinsCount / 2; i < _coinsCount / 2; i++)
            {
                coinPosition.y = Mathf.Max(-1 / 2f * Mathf.Pow(i, 2) + 3, _coinsHeight);
                CreateNexCoin(i, coinPosition, spawn, prefabCoin);
            }
        }
    }

    private void CreateNexCoin(int i, Vector3 coinPosition, Vector3 spawn, GameObject prefabCoin)
    {
        coinPosition.z = i * ((float)_itemSpeace / _coinsCount);
        GameObject spawned = Instantiate(prefabCoin, coinPosition + spawn, Quaternion.identity, transform);
    }
}
