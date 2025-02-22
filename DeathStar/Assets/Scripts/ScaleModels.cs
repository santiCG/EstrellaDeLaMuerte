using System.Collections;
using UnityEngine;

public class ScaleModels : MonoBehaviour
{
    [SerializeField] GameObject[] estrellas;

    private float[] escalaGrande = new float[3];
    private float[] escalaChiquita = new float[3];

    private int index = 1;

    private Vector3 targetScale;

    void Start()
    {
        escalaGrande[0] = 9.8f;
        escalaGrande[1] = 0.01f;
        escalaGrande[2] = 0.01f;

        escalaChiquita[0] = 2;
        escalaChiquita[1] = 0.003f;
        escalaChiquita[2] = 0.003f;
    }

    public void cambiarEscala()
    {
        switch (index)
        {
            case 1:
                targetScale = new Vector3(escalaGrande[1], escalaGrande[1], escalaGrande[1]);
                StartCoroutine(ScaleOverTime(targetScale, 0.5f, 1));

                targetScale = new Vector3(escalaChiquita[0], escalaChiquita[0], escalaChiquita[0]);
                StartCoroutine(ScaleOverTime(targetScale, 0.5f, 0));
                targetScale = new Vector3(escalaChiquita[2], escalaChiquita[2], escalaChiquita[2]);
                StartCoroutine(ScaleOverTime(targetScale, 0.5f, 2));

                index++;
                break;
            case 2:
                targetScale = new Vector3(escalaGrande[2], escalaGrande[2], escalaGrande[2]);
                StartCoroutine(ScaleOverTime(targetScale, 0.5f, 2));

                targetScale = new Vector3(escalaChiquita[0], escalaChiquita[0], escalaChiquita[0]);
                StartCoroutine(ScaleOverTime(targetScale, 0.5f, 0));
                targetScale = new Vector3(escalaChiquita[1], escalaChiquita[1], escalaChiquita[1]);
                StartCoroutine(ScaleOverTime(targetScale, 0.5f, 1));

                index++;
                break;

            case 3:
                targetScale = new Vector3(escalaGrande[0], escalaGrande[0], escalaGrande[0]);
                StartCoroutine(ScaleOverTime(targetScale, 0.5f, 0));

                targetScale = new Vector3(escalaChiquita[2], escalaChiquita[2], escalaChiquita[2]);
                StartCoroutine(ScaleOverTime(targetScale, 0.5f, 2));
                targetScale = new Vector3(escalaChiquita[1], escalaChiquita[1], escalaChiquita[1]);
                StartCoroutine(ScaleOverTime(targetScale, 0.5f, 1));

                index = 1;
                break;
        }
    }

    IEnumerator ScaleOverTime(Vector3 target, float time, int i)
    {
        Vector3 initialScale = estrellas[i].transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            estrellas[i].transform.localScale = Vector3.Lerp(initialScale, target, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        estrellas[i].transform.localScale = target;
    }
}
