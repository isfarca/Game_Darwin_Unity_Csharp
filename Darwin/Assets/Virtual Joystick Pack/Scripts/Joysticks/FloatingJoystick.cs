using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    private Vector2 _joystickCenter = Vector2.zero;

    private void Start()
    {
        Background.gameObject.SetActive(false);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - _joystickCenter;
        InputVector = (direction.magnitude > Background.sizeDelta.x / 2f)
            ? direction.normalized
            : direction / (Background.sizeDelta.x / 2f);
        ClampJoystick();
        Handle.anchoredPosition = (InputVector * Background.sizeDelta.x / 2f) * HandleLimit;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Background.gameObject.SetActive(true);
        Background.position = eventData.position;
        Handle.anchoredPosition = Vector2.zero;
        _joystickCenter = eventData.position;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        Background.gameObject.SetActive(false);
        InputVector = Vector2.zero;
    }
}