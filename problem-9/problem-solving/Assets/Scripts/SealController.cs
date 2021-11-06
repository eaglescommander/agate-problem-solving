using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SealController : MonoBehaviour
{
    [SerializeField] private int value = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(value);
            Destroy(gameObject);
        }
    }
}
