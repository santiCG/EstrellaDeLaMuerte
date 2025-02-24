using UnityEngine;

public class ExitApp : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Exiting application");
        Application.Quit();
    }
}
