using System.Diagnostics;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private float soundVolume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        try
        {
            GameManager.Instance?.AddScore(value);
        }
        catch (System.NullReferenceException)
        {
            UnityEngine.Debug.LogWarning("GameManager non trouvé, mais pièce collectée");
        }

        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position, soundVolume);
        }
        else
        {
            UnityEngine.Debug.LogWarning("Aucun son assigné pour la pièce");
        }

        Destroy(gameObject);
    }
}
