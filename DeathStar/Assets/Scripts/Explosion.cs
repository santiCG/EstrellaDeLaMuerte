using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject originalStar;
    [SerializeField] private GameObject fracturedStar;
    [SerializeField] private float minExplosionForce = 10f;
    [SerializeField] private float maxExplosionForce = 100f;
    [SerializeField] private float explosionRadius = 10f;
    [SerializeField] private float fragScaleFactor;

    public void Explode(){
        if (originalStar == null || fracturedStar == null) return;

        originalStar.SetActive(false);
        fracturedStar.SetActive(true);

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
