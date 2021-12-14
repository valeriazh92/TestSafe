using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelController : MonoBehaviour, IPointerClickHandler
{
    Animator animator;
    void start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public static event Action ClickToNowhereHandler;

    public void OnPointerClick(PointerEventData eventData)
    {
        animator = GetComponentInChildren<Animator>();
        animator.Play("Base Layer.WindowClose" );
        StartCoroutine(WaitForAnim());
    }
    IEnumerator WaitForAnim()
    {
        
        yield return new WaitForSeconds(0.5f);
        ClickToNowhereHandler.Invoke();
    }
}
