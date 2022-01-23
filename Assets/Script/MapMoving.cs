using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMoving : MonoBehaviour
{
    bool isDragging = false;

    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                OnMouseDown();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                OnMouseUp();
            }
        }

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, 0, 0);
            if(transform.position.x < 0)
            {
                transform.position = new Vector3(0, 0, 0);
            }
            else if (transform.position.x > 5.5f)
            {
                transform.position = new Vector3(5.5f, 0, 0);
            }
        }
    }
}
