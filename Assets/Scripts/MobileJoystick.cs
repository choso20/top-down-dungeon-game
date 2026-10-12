using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MobileJoystick : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    private RectTransform joystickTransform;

    [SerializeField] private float dragThreshold = 0.4f;
    [SerializeField] private int dragMovementDistance = 30;
    [SerializeField] private int dragOffsetDistance = 150;

    public delegate void Movement(Vector2 vec2);
    public static event Movement OnnMove;
    
    Scene scene;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickTransform,
            eventData.position,
            null,
            out offset);
        offset = Vector2.ClampMagnitude(offset, dragOffsetDistance) / dragOffsetDistance;
        joystickTransform.anchoredPosition = offset * dragMovementDistance;

        Vector2 inputVector = CalculateMovementInput(offset);
        OnnMove?.Invoke(inputVector);
    }

    private Vector2 CalculateMovementInput(Vector2 offset)
    {
        float x = MathF.Abs(offset.x) > dragThreshold ? offset.x : 0;
        float y = MathF.Abs(offset.y) > dragThreshold ? offset.y : 0;
        return new Vector2(x, y);
    }



    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickTransform.anchoredPosition = Vector2.zero;
        OnnMove?.Invoke(Vector2.zero);
    }

    private void Awake()
    {
        joystickTransform = (RectTransform)transform;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        joystickTransform.anchoredPosition = Vector2.zero;
        OnnMove?.Invoke(Vector2.zero);
    }
}
