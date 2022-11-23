using UnityEngine;
using UnityEngine.EventSystems;

public class Dish : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private SpriteRenderer _sprite;
    private Color initColour;
    private Color hoverColour;
    private GameObject currentTower;

    public float colourHighlightModifier = 1.1f;

    /// <summary> Awake is called when the script instance is being loaded. </summary>
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        initColour = _sprite.color;
        hoverColour = new Color(
            _sprite.color.r * colourHighlightModifier,
            _sprite.color.g * colourHighlightModifier,
            _sprite.color.b * colourHighlightModifier
        );
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // if (currentTower == null && eventData.button == PointerEventData.InputButton.Left) {
        //     currentTower = (GameObject)GameManager.Instance.SpawnTower(transform);
        // }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _sprite.color = hoverColour;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _sprite.color = initColour;
    }
}
