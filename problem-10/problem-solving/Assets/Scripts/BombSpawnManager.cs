using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawnManager : MonoBehaviour
{
    private static BombSpawnManager _instance = null; 
    public static BombSpawnManager Instance 
    { 
        get 
        { 
            if (_instance == null) 
            { 
                _instance = FindObjectOfType<BombSpawnManager> (); 
            } 
            return _instance; 
        } 
    }
    [SerializeField] GameObject bombPrefab;
    [SerializeField] BoxCollider2D spawnArea;
 
    Vector3 spawnSize;
    Vector3 spawnCenter;

    public float radius = 3f;

    [SerializeField] private float _spawnDelay = 5f;
    private float _runningSpawnDelay;

    private void Awake()
    {
        Transform spawnTransform = spawnArea.GetComponent<Transform>();
        spawnCenter = spawnTransform.position;

        spawnSize.x = spawnTransform.localScale.x * spawnArea.size.x;
        spawnSize.y = spawnTransform.localScale.y * spawnArea.size.y;
        spawnSize.z = 0f;
    }

    private void Update()
    {
        _runningSpawnDelay -= Time.unscaledDeltaTime;
        if (_runningSpawnDelay <= 0f)
        {
            Spawn();
            _runningSpawnDelay = _spawnDelay;
        }
    }

    public void Spawn()
    {
        bool canSpawnHere;
        int attempt = 0;
        
        Vector3 spawnPost = GetRandomPosition();
        canSpawnHere = PreventSpawnOverlap(spawnPost);

        while (!canSpawnHere || attempt < 100)
        {
            spawnPost = GetRandomPosition();
            canSpawnHere = PreventSpawnOverlap(spawnPost);
            attempt++;
        }

        Instantiate(bombPrefab, spawnPost, Quaternion.identity, gameObject.GetComponent<Transform>());
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-spawnSize.x / 2, spawnSize.x / 2), Random.Range(-spawnSize.y / 2, spawnSize.y / 2), 0f);

        return spawnCenter + randomPosition;
    }

    private bool PreventSpawnOverlap(Vector3 pos)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, radius);

        //Including spawn area
        if (colliders.Length > 1)
        {
            return false;
        }

        return true;
    }
}
