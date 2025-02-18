using UnityEngine;
using Vuforia;

public class TrackCubeRotation : MonoBehaviour
{
    [SerializeField] private GameObject deathStarTransform;

    private Vector3 startPos;

    //void Start()
    //{
    //    startPos = deathStarTransform.position;
    //}

    //void Update()
    //{
    //    // Sincroniza la rotación de la Estrella de la Muerte con el Multi Target
    //    //deathStarTransform.position = startPos;
    //    //deathStarTransform.localPosition = deathStarTransform.InverseTransformDirection(startPos);

    //    deathStarTransform.position = posAnchor.position;
    //    deathStarTransform.localPosition = deathStarTransform.InverseTransformDirection(posAnchor.position);

    //    deathStarTransform.rotation = transform.rotation;
    //}

    private void Update()
    {
        deathStarTransform.transform.rotation = transform.rotation;
    }

    public void showDeathStar()
    {
        deathStarTransform.SetActive(true);
    }

    public void hideDeathStar()
    {
        deathStarTransform.SetActive(true);
    }
}
