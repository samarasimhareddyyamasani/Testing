using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class Hover : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public GameObject button;
    
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        button.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.transform.DOScale(new Vector3(1, 1, 1), 1);

    }
}
