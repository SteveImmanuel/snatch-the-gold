using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler
{
    public Transform panel;
    public Transform deck;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //transform.SetParent(panel);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.SetParent(deck);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log(gameObject.name);
    }








    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
