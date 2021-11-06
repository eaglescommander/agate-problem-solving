using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealControllerRespawn : MonoBehaviour
{
    [SerializeField] private int value = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(value);
            gameObject.SetActive(false);
            Invoke("Respawn", 3);
        }
    }

    void Respawn()
    {
        SealSpawnManager.Instance.Respawn(gameObject);
    }
}
