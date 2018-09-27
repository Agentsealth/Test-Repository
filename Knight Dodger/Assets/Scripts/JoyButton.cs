using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyButton : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    public Image bgImg;
    public Image joystickImg;
    private Vector2 Vec;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.rect.x);
            pos.y = (pos.y / bgImg.rectTransform.rect.y);

            Vec = new Vector2(pos.x * 2, pos.y*2);
            Vec = (Vec.magnitude > 1.0f) ? Vec.normalized : Vec;

            joystickImg.rectTransform.anchoredPosition = new Vector3(Vec.x * (bgImg.rectTransform.rect.x / 2), Vec.y * (bgImg.rectTransform.rect.y / 2));

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vec = Vector2.zero;
        joystickImg.rectTransform.anchoredPosition = Vec;

    }

    public float Horizontal()
    {
        if (Vec.x != 0)
            return -Vec.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (Vec.y != 0)
            return -Vec.y;
        else
            return Input.GetAxis("Vertical");
    }
}
