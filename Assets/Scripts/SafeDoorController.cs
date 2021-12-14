using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SafeDoorController : MonoBehaviour
{
    public static event Action WindowOpenHandler;
    public GameObject SafeWindow;
    public AudioClip clipOpenWindow;
    public AudioClip clipCloseWindow;
    public AudioClip clipOpenSafeDoor;
    public ParticleSystem particle;
    private bool isOpened = false;
    private bool isDoorOpening = false;

    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SafeController.PuzzleCompliteHandler += OpenSafe;
    }
   
   private void OnMouseDown()
    {
        
        if (!isOpened&&!isDoorOpening)
        {
            isDoorOpening = true;
            WindowOpenHandler.Invoke();
            SafeWindow.SetActive(true);
            audioSource.Play();
            audioSource.PlayOneShot(clipOpenWindow);
            PanelController.ClickToNowhereHandler += WindowClose;
        }

    }
    public void WindowClose()
    {
        isDoorOpening = false;
        SafeWindow.SetActive(false);
        if (!isOpened)
        {
          audioSource.PlayOneShot(clipCloseWindow);
        }

    }
    private void OpenSafe()
    {
       audioSource.PlayOneShot(clipOpenSafeDoor);
        WindowClose();
        isOpened = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        particle.Play();
    }
}
