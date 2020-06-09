using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!FindObjectOfType<PlayerController>().isAlive) { return; }

        int points = 50;
        AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddScore(points);
        Destroy(gameObject);
    }
}
