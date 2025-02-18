using UnityEngine;

public class OnClicking : MonoBehaviour
{
    Animator animator;
    bool dancing;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
        {
            dancing = true;
            animator.SetBool("Dance", true);
        }
        else
        {
            dancing= false;
            animator.SetBool("Dance", false);
        }
    }
}
