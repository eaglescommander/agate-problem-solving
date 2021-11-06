using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealSpawnManager : MonoBehaviour
{
    private static SealSpawnManager _instance = null; 
    public static SealSpawnManager Instance 
    { 
        get 
        { 
            if (_instance == null) 
            { 
                _instance = FindObjectOfType<SealSpawnManager> (); 
            } 
            return _instance; 
        } 
    }
    [SerializeField] GameObject sealPrefab;
    [SerializeField] BoxCollider2D spawnArea;
 
    Vector3 spawnSize;
    Vector3 spawnCenter;

    public float radius = 1.5f;

    private void Awake()
    {
        Transform spawnTransform = spawnArea.GetComponent<Transform>();
        spawnCenter = spawnTransform.position;

        spawnSize.x = spawnTransform.localScale.x * spawnArea.size.x;
        spawnSize.y = spawnTransform.localScale.y * spawnArea.size.y;
        spawnSize.z = 0f;
    }

    private void Start()
    {
        for (int i=0; i<5; i++)
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

            Instantiate(sealPrefab, spawnPost, Quaternion.identity, gameObject.GetComponent<Transform>());
        }
    }

    public void Respawn(GameObject item)
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

        item.GetComponent<Transform>().position = spawnPost;
        item.SetActive(true);
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
