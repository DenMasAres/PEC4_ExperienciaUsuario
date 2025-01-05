using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class BowStringController : MonoBehaviour
{
    [SerializeField]
    private BowString bowStringrenderer;

    private XRGrabInteractable interactable;

    [SerializeField]
    private Transform midPointGrabObject, midPointVisualObject, midPointParent;

    [SerializeField]
    private float bowStringStretchLimit = 1f;

    private Transform interactor;

    private float strength;

    public UnityEvent OnBowPulled;
    public UnityEvent<float> OnBowReleased;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip reload;
    [SerializeField] AudioClip release;

    private void Awake()
    {
        interactable = midPointGrabObject.GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        interactable.selectEntered.AddListener(PrepareBowString);
        interactable.selectExited.AddListener(ResetBowString);
    }

    
    private void Update()
    {
        if(interactor != null)
        {
            Vector3 midPointLocalSpace = midPointParent.InverseTransformPoint(midPointGrabObject.position);

            //float midPointLocalZAbs = Mathf.Abs(midPointLocalSpace.z);
            float midPointLocalXAbs = Mathf.Abs(midPointLocalSpace.x);

            HandleStringPushedBackToStart(midPointLocalSpace);

            HandleStringPulledBackToLimit(midPointLocalXAbs, midPointLocalSpace);

            HandlePullingString(midPointLocalXAbs, midPointLocalSpace);

            bowStringrenderer.CreateString(midPointVisualObject.transform.position);
        }

    }

    private void HandlePullingString(float midPointLocalXAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.x < 0 && midPointLocalXAbs < bowStringStretchLimit)
        {
            strength = Remap(midPointLocalXAbs, 0 , bowStringStretchLimit, 0, 1);
            midPointVisualObject.localPosition = new Vector3(midPointLocalSpace.x, 0, 0);
        }
    }

    private float Remap(float value, int fromMin, float fromMax, int toMin, int toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }

    private void HandleStringPulledBackToLimit(float midPointLocalXAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.x < 0 && midPointLocalXAbs >= bowStringStretchLimit)
        {
            midPointVisualObject.localPosition = new Vector3(-bowStringStretchLimit, 0, 0);
            strength = 1;
        }
    }

    private void HandleStringPushedBackToStart(Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.x >= 0)
        {
            midPointVisualObject.localPosition = Vector3.zero;
            strength = 0;
        }
    }

    private void PrepareBowString(SelectEnterEventArgs arg0)
    {
        interactor = arg0.interactorObject.transform;
        audioSource.PlayOneShot(reload);
        OnBowPulled?.Invoke();
    }
    
    private void ResetBowString(SelectExitEventArgs arg0)
    {
        audioSource.PlayOneShot(release);
        OnBowReleased?.Invoke(strength);
        strength = 0;

        interactor = null;
        midPointGrabObject.localPosition = Vector3.zero;
        midPointVisualObject.localPosition = Vector3.zero;
        bowStringrenderer.CreateString(null);
    }

}

