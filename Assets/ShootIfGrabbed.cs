using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootIfGrabbed : MonoBehaviour {

    private SimpleShoot simpleShoot;
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;
    public int maxNumberOfBullets = 10;
    public Text bulletText;
    public AudioClip shootingAudio;

	// Use this for initialization
	void Start () {
        simpleShoot = GetComponent<SimpleShoot>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
        bulletText.text = maxNumberOfBullets.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(shootingButton, ovrGrabbable.grabbedBy.GetController()) && maxNumberOfBullets > 0)
        {
            // Shoot!

            VibrationManager.singleton.TriggerVibration(40, 2 ,255 ,ovrGrabbable.grabbedBy.GetController());
            //Trigger Haptic :
            //DONT DO THIS !!! OVRInput.SetControllerVibration(0.5f, 0.5f, ovrGrabbable.grabbedBy.GetController());

            //DO THIS
            GetComponent<AudioSource>().PlayOneShot(shootingAudio);
            simpleShoot.TriggerShoot();
            maxNumberOfBullets--;
            bulletText.text = maxNumberOfBullets.ToString();
        }
	}
}
