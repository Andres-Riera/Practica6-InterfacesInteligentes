using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Renderer))]
public class ColorChangeOnSelect : MonoBehaviour
{
    [SerializeField] private Color selectColor = Color.green;
    private Color originalColor;
    private Renderer objRenderer;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    private void Awake()
    {
        objRenderer = GetComponent<Renderer>();
        originalColor = objRenderer.material.color;
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
    }

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnSelectEntered);
        interactable.selectExited.AddListener(OnSelectExited);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnSelectEntered);
        interactable.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        objRenderer.material.color = selectColor;
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        objRenderer.material.color = originalColor;
    }
}