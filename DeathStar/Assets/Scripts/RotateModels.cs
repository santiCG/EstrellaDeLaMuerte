using System;
using TMPro;
using UnityEngine;

public class RotateModels : MonoBehaviour
{
    [SerializeField] Transform[] stars;
    [SerializeField] private int rotationSpeed = 20;
    [SerializeField] MoveModels moveModels;

    private Quaternion[] initialRot;
    private bool rotateAll = true;

    void Update()
    {
        if (rotateAll)
        {
            HandleRotation();
        }
        else
        {
            StopRotateModel(moveModels.index);
        }
    }

    private void HandleRotation()
    {
        stars[0].Rotate(0, rotationSpeed * Time.deltaTime, 0);
        stars[1].Rotate(0, 0, rotationSpeed * Time.deltaTime);
        stars[2].Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void StopRotateModel(int index)
    {
        switch (index)
        {
            case 1:

                //Quaternion lookDir = Quaternion.LookRotation(new Vector3(287.914398f, 299.634583f, 198.576096f), stars[1].up);
                //stars[1].rotation = Quaternion.RotateTowards(stars[1].rotation, lookDir, rotationSpeed * Time.deltaTime);
                stars[1].Rotate(0, 0, 0);

                stars[0].Rotate(0, rotationSpeed * Time.deltaTime, 0);
                stars[2].Rotate(0, rotationSpeed * Time.deltaTime, 0);
                break;
            case 2:
                stars[0].Rotate(0, 0, 0);

                stars[1].Rotate(0, 0, rotationSpeed * Time.deltaTime);
                stars[2].Rotate(0, rotationSpeed * Time.deltaTime, 0);
                break;

            case 3:
                stars[2].Rotate(0, 0, 0);

                stars[1].Rotate(0, 0, rotationSpeed * Time.deltaTime);
                stars[0].Rotate(0, rotationSpeed * Time.deltaTime, 0);
                break;
        }
    }
    public void ChangeRotationState()
    {
        rotateAll = !rotateAll;
    }
}
