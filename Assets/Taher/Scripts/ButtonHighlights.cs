using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlights : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("Base Layer", true); // Assuming you have a bool parameter in the Animator
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("Base Layer", false);
    }
}