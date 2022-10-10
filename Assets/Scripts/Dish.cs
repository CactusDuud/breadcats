using UnityEngine;

public class Dish : MonoBehaviour
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

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    private void OnMouseDown()
    {
        if (currentTower == null) {
            currentTower = (GameObject)GameManager.Instance.SpawnTower(transform);
        }
    }

    /// <summary> Called when the mouse enters the GUIElement or Collider. </summary>
    private void OnMouseEnter()
    {
        _sprite.color = hoverColour;
    }

    /// <summary> Called when the mouse is not any longer over the GUIElement or Collider. </summary>
    private void OnMouseExit()
    {
        _sprite.color = initColour;
    }
}
