using UnityEngine;
using UnityEngine.VFX;
using System.Collections;  

public class Explosion : MonoBehaviour
{
    [Header("Explosion Settings")]
    [SerializeField] private GameObject originalStar;
    [SerializeField] private GameObject fracturedStar;

    [Header("Explosion Parameters")]
    [SerializeField] private float minExplosionForce = 10f;
    [SerializeField] private float maxExplosionForce = 100f;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionDelay = 0.2f; 
    [SerializeField] private float fragScaleFactor;

    [Header("Explosion Effects")]
    [SerializeField] private VisualEffect explosionEffect;

    public void Explode(){
        if (originalStar == null || fracturedStar == null) return;

        originalStar.SetActive(false);
        fracturedStar.SetActive(true);

        if (explosionEffect != null)
        {
            explosionEffect.Play();
        }

        StartCoroutine(DelayedExplosionForce());
    }

    private IEnumerator DelayedExplosionForce()
    {
        yield return new WaitForSeconds(explosionDelay);

        foreach (Transform child in fracturedStar.transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.AddExplosionForce(Random.Range(minExplosionForce, maxExplosionForce), transform.position, explosionRadius);
            }
        }

        Destroy(fracturedStar, 10f);
    }
}
