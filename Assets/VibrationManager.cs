﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour {

    public static VibrationManager singleton;

	// Use this for initialization
	void Start () {

        if (singleton && singleton != this)
            Destroy(this);
        else
            singleton = this;
	}
    public void TriggerVibration(AudioClip vibrationAudio, OVRInput.Controller controller)
    {

        OVRHapticsClip clip = new OVRHapticsClip(vibrationAudio);
        if (controller == OVRInput.Controller.LTouch)
        {
            // Trigger On left controller
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (controller == OVRInput.Controller.RTouch)
        {
            // Trigger On right controller
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }
    public void TriggerVibration(int iteration, int frequency, int strength, OVRInput.Controller controller)
    {

        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i = 0; i < iteration; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte) strength : (byte) 0);
            
        }

        if (controller == OVRInput.Controller.LTouch)
        {
            // Trigger On left controller
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (controller == OVRInput.Controller.RTouch)
        {
            // Trigger On right controller
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }

}
