using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PinController : MonoBehaviour,IPointerClickHandler
{
    public static event Action<string, int> CodeChanged = delegate { };
    private int[] pinYpos = { 310, 255 ,200, 145, 90, 35 };//{ 35, 90 ,145, 200, 255, 310 }
    private bool isAllowed = true;
    private int currentPos=0;

    Animator animator;
    AudioSource audioSource;

    public AudioClip [] clip;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isAllowed) { ChangePosition(); }
    }

    private void ChangePosition()
    {
        isAllowed = false;
        currentPos--;
        if (currentPos < 0) { currentPos = pinYpos.Length-1;  }

        if (currentPos == 5) { audioSource.PlayOneShot(clip[4],1.5f); }
        else {
                audioSource.PlayOneShot(clip[UnityEngine.Random.Range(0, 4)]);
             }

        transform.localPosition = new Vector2(transform.localPosition.x, pinYpos[currentPos]);
        animator.Play("Base Layer." + (6-(currentPos+1)));
        CodeChanged(name, currentPos + 1);//send data
        isAllowed = true;
    }
    
    public void SetStartPosition(int positionY)
    {
        currentPos = positionY-1;
        transform.localPosition = new Vector2(transform.localPosition.x, pinYpos[currentPos]);
    }

}
