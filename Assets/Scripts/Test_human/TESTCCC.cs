using UnityEngine;
using UnityEngine.UI;

public class TESTCCC : MonoBehaviour
{
    enum ButtonType
    {
        Left,
        Right
    }

    const float MAX_ANGLE = 30;
    
    public ButtonCust buttonLeft;
    public ButtonCust buttonRight;
    public Text angelLabel;

    public float currenrtAngle;
    private float targetAngle;
    public float speed;

    private bool isLeftPressed = false;
    private bool isRightPressed = false;
    private float velocity;

    void Awake()
    {
        buttonLeft.onPointer += (pointerDown) => {
            onPointerHandler(ButtonType.Left, pointerDown, ref isLeftPressed, ref isRightPressed);
        };

        buttonRight.onPointer += (pointerDown) => {
            onPointerHandler(ButtonType.Right, pointerDown, ref isRightPressed, ref isLeftPressed);
        };
    }

    void Update()
    {
        currenrtAngle = Mathf.SmoothDamp(currenrtAngle, targetAngle, ref velocity, speed * Time.deltaTime);
    }   

    private void onPointerHandler(ButtonType buttonType, bool pointerDown, ref bool target, ref bool other)
    {
        target = pointerDown;
        if(pointerDown && !other)
            targetAngle = buttonType == ButtonType.Left ? -MAX_ANGLE: MAX_ANGLE;
        else if(!pointerDown && other)
        {
            other = true;
            targetAngle = buttonType == ButtonType.Left ? MAX_ANGLE: -MAX_ANGLE;
        }
        else
            targetAngle = 0;
    }
}
