using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor = Color.red;
    private Color originalColor;
    private Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
        originalColor = textComponent.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textComponent.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textComponent.color = originalColor;
    }
}
