using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// This class provides a hover effect for UI images.
/// </summary>
public class ImageHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image targetImage;
    [SerializeField] private Color normalColor = Color.clear;
    [SerializeField] private Color hoverColor = Color.white;

    void Start()
    {
        if (targetImage == null)
            targetImage = GetComponent<Image>();

        targetImage.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetImage.color = normalColor;
    }
}