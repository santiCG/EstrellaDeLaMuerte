using System.Collections;
using System.Net;
using UnityEngine;

public class MoveModels : MonoBehaviour
{
    public float speed = 2f;

    [SerializeField] Transform[] points;
    [SerializeField] Transform[] stars;

    [SerializeField] ActivateTexts actTexts;
    [SerializeField] ChangeTextPanels changeTexts;

    public int index = 1;

    public void buttonMove()
    {
        switch (index)
        {
            case 1:
                StartCoroutine(MoveStars(stars[0], 0, 1, 2));
                StartCoroutine(MoveStars(stars[1], 2, 3, 4));
                StartCoroutine(MoveStars(stars[2], 4, 5, 0));

                actTexts.ChangeState(1);
                changeTexts.changeTxtPanels(1);
                index++;
                break;
            case 2:
                StartCoroutine(MoveStars(stars[0], 2, 3, 4));
                StartCoroutine(MoveStars(stars[1], 4, 5, 0));
                StartCoroutine(MoveStars(stars[2], 0, 1, 2));

                actTexts.ChangeState(2);
                changeTexts.changeTxtPanels(2);
                index++;
                break;
            
            case 3:
                StartCoroutine(MoveStars(stars[0], 4, 5, 0));
                StartCoroutine(MoveStars(stars[1], 0, 1, 2));
                StartCoroutine(MoveStars(stars[2], 2, 3, 4));

                actTexts.ChangeState(0);
                changeTexts.changeTxtPanels(3);
                index = 1;
                break;
        }
    }

    Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        return (u * u) * p0 + (2 * u * t) * p1 + (t * t) * p2;
    }

    IEnumerator MoveStars(Transform star, int start, int middle, int end)
    {
        float t = 0f;
        
        while (t< 1f)
        {
            t += speed * Time.deltaTime;
            star.position = CalculateBezierPoint(t, points[start].position, points[middle].position, points[end].position);
            yield return null;
        }
    }
}
