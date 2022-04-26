using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour
{
    public delegate void DragEndEvent(int id);
    public static event DragEndEvent OnDragEnd;
    public bool isActive = true;

    private void OnMouseDrag()
    {
        if(isActive)
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 convertedMousePos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = convertedMousePos;
        }
    }
}
