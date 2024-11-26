using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor;
    public Color unableColor;
    public Text userInput;
    private Color originalColor;
    private Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
        originalColor = textComponent.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!string.IsNullOrEmpty(userInput.text))
        {
            textComponent.color = hoverColor;
        }
        else
        {
            textComponent.color = unableColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textComponent.color = originalColor;
    }
}
