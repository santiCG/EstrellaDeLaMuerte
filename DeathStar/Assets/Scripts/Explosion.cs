using UnityEngine;
using UnityEngine.VFX;
using System.Collections;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
    [Header("Explosion Settings")]
    [SerializeField] private GameObject originalStar;
    [SerializeField] private GameObject fracturedStarPrefab;

    [Header("Explosion Parameters")]
    [SerializeField] private float minExplosionForce = -100f;
    [SerializeField] private float maxExplosionForce = 100f;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionDelay = 0.2f; 
    [SerializeField] private float fragScaleFactor;

    [Header("Explosion Effects")]
    private VisualEffect explosionEffect;

    [Header("Index Info ")]
    [SerializeField] private GameObject explosionButton;
    [SerializeField] private MoveModels mm;
    [SerializeField] AudioSource _audio;

    private bool isExploding = false;
    private GameObject fracturedStarInstance;

    public void Sart()
    {
        explosionEffect = fracturedStarPrefab.GetComponent<VisualEffect>();

        if (explosionEffect == null)
        {
            Debug.LogError("Explosion effect not found on fractured star prefab!");
        }
    }

    public void Update()
    {
        if(mm.index == 2)
        {
            explosionButton.SetActive(true);
        }
        else
        {
            explosionButton.SetActive(false);
        }
    }

    public void Explode()
    {
        if (isExploding) return;
        if (originalStar == null || fracturedStarPrefab == null) return;
        if (mm.index != 2) return;

        originalStar.SetActive(false);
        fracturedStarInstance = Instantiate(fracturedStarPrefab, originalStar.transform.position, originalStar.transform.rotation);

        if (explosionEffect != null)
        {
            explosionEffect.Play();
        }

        StartCoroutine(DelayedExplosionForce());   
    }

    private IEnumerator DelayedExplosionForce()
    {
        yield return new WaitForSeconds(explosionDelay);

        foreach (Transform child in fracturedStarInstance.transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.AddExplosionForce(Random.Range(minExplosionForce, maxExplosionForce), transform.position, explosionRadius);
            }
        }

        _audio.Play();
        Destroy(fracturedStarInstance, 6f);

        yield return new WaitForSeconds(6);
        originalStar.SetActive(true);
        isExploding = false;
    }
}
