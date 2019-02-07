using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    private Vector2 _joystickPosition = Vector2.zero;
    private readonly Camera _cam = new Camera();

    private void Start()
    {
        _joystickPosition = RectTransformUtility.WorldToScreenPoint(_cam, Background.position);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - _joystickPosition;
        InputVector = (direction.magnitude > Background.sizeDelta.x / 2f)
            ? direction.normalized
            : direction / (Background.sizeDelta.x / 2f);
        ClampJoystick();
        Handle.anchoredPosition = (InputVector * Background.sizeDelta.x / 2f) * HandleLimit;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        InputVector = Vector2.zero;
        Handle.anchoredPosition = Vector2.zero;
    }
}