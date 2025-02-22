using UnityEngine;

public class ActivateTexts : MonoBehaviour
{
    [SerializeField] GameObject[] textsContainer;

    public bool textsDesactivated;

    private int index;

    private void Start()
    {
        DesactivateText();
    }

    public void ChangeState(int j)
    {
        index = j;

        if (textsDesactivated) return;

        for (int i = 0; i < textsContainer.Length; i++)
        {
            if(i == index)
            {
                textsContainer[i].SetActive(true);
            }
            else
            {
                textsContainer[i].SetActive(false);
            }
        }
    }

    public void DesactivateText()
    {
        if(!textsDesactivated)
        {
            foreach (GameObject t in textsContainer)
            {
                t.SetActive(false);
            }
            textsDesactivated = true;
        }
        else
        {
            textsDesactivated = false;
            ChangeState(index);
        }
    }
}
