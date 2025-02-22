using System;
using UnityEngine;

public class ChangeTextPanels : MonoBehaviour
{
    [SerializeField] GameObject[] textPanels;

    public void changeTxtPanels(int index)
    {
        switch (index)
        {
            case 1:
                textPanels[0].SetActive(true);
                textPanels[1].SetActive(false);
                textPanels[2].SetActive(false);
                break;
            case 2:
                textPanels[0].SetActive(false);
                textPanels[1].SetActive(false);
                textPanels[2].SetActive(true);
                break;

            case 3:
                textPanels[0].SetActive(false);
                textPanels[1].SetActive(true);
                textPanels[2].SetActive(false);
                break;
        }
    }
}
