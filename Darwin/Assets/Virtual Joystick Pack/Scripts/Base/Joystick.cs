using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [Header("Options")]
    [Range(0f, 2f)] public float HandleLimit = 1f;
    public JoystickMode JoystickMode = JoystickMode.AllAxis;
    protected Vector2 InputVector = Vector2.zero;
    [Header("Components")]
    public RectTransform Background;
    public RectTransform Handle;
    public float Horizontal { get { return InputVector.x; } }
    public float Vertical { get { return InputVector.y; } }
    public Vector2 Direction { get { return new Vector2(Horizontal, Vertical); } }

    public virtual void OnDrag(PointerEventData eventData)
    {

    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {

    }

    protected void ClampJoystick()
    {
        switch (JoystickMode)
        {
            case JoystickMode.Horizontal:
                InputVector = new Vector2(InputVector.x, 0f);
                break;
            case JoystickMode.Vertical:
                InputVector = new Vector2(0f, InputVector.y);
                break;
            case JoystickMode.AllAxis:
                return;
            default:
                return;
        }
    }
}

public enum JoystickMode { AllAxis, Horizontal, Vertical}
