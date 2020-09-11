using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MovementPlayer : MonoBehaviour
{
    // Variables
    [Header("Player Controls")]
    public InputAction moveAction;

    public float Speed = 1;

    private Rigidbody2D oRigidBody;

    // Functions
    private void Awake()
    {
        oRigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 oldValue = oRigidBody.velocity;
        Vector3 newValue;

        // Accelerometer
        if (Accelerometer.current != null) // Zorgt voor ERROR op Unity. Verander naar == null om zonder ERROR te spelen
        {
            newValue = Accelerometer.current.acceleration.ReadValue().normalized * Speed;
            
            Camera oCamera = Camera.main;
            ///newValue = new Vector3();
            var oTouch = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches;
            for (int i = 0; i < oTouch.Count(); i++)
            {
                var oVector = (Vector2)oCamera.ScreenToWorldPoint(new Vector3(oTouch[i].startScreenPosition.x, oTouch[i].startScreenPosition.y, 0.0f));

                if (oVector.x < 0.0f) oVector.x = -1.0f;
                else if (oVector.x > 0.0f) oVector.x = 1.0f;
                else oVector.x = 0.0f;
                oVector.y = 0.0f;

                newValue = oVector.normalized * Speed;
            }
        }
        // Arrows (Unity PC testing)
        else
            newValue = moveAction.ReadValue<Vector2>().normalized * Speed;

        newValue = Vector2.Lerp(oldValue, newValue, .1f);
        oRigidBody.velocity = newValue;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        if (Accelerometer.current != null)
        { 
            InputSystem.EnableDevice(Accelerometer.current);
            InputSystem.EnableDevice(Touchscreen.current); // Kan denk ik weg
            EnhancedTouchSupport.Enable();
        }
    }

    private void OnDisable()
    {
        moveAction.Disable();
        if (Accelerometer.current != null)
        {
            InputSystem.DisableDevice(Accelerometer.current);
            InputSystem.DisableDevice(Touchscreen.current); // Kan denk ik weg
            EnhancedTouchSupport.Disable();
        }
    }
}
