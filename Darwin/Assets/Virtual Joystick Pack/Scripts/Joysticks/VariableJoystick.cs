using UnityEngine;
using UnityEngine.EventSystems;

public class VariableJoystick : Joystick
{
    [Header("Variable Joystick Options")]
    public bool IsFixed = true;
    public Vector2 FixedScreenPosition;

    private Vector2 _joystickCenter = Vector2.zero;

    private void Start()
    {
        if (IsFixed)
            OnFixed();
        else
            OnFloat();
    }

    public void ChangeFixed(bool joystickFixed)
    {
        if (joystickFixed)
            OnFixed();
        else
            OnFloat();
        IsFixed = joystickFixed;
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
        if (IsFixed)
            return;
        
        Background.gameObject.SetActive(true);
        Background.position = eventData.position;
        Handle.anchoredPosition = Vector2.zero;
        _joystickCenter = eventData.position;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (!IsFixed)
        {
            Background.gameObject.SetActive(false);
        }
        InputVector = Vector2.zero;
        Handle.anchoredPosition = Vector2.zero;
    }

    private void OnFixed()
    {
        _joystickCenter = FixedScreenPosition;
        Background.gameObject.SetActive(true);
        Handle.anchoredPosition = Vector2.zero;
        Background.anchoredPosition = FixedScreenPosition;
    }

    private void OnFloat()
    {
        Handle.anchoredPosition = Vector2.zero;
        Background.gameObject.SetActive(false);
    }
}