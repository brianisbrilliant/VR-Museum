using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Content.Interaction;

public class slidertest : MonoBehaviour
{
    public XRSlider slider;
    public Transform cube;

    public void OnChangeValue(float value) {
        Debug.Log("Value = " + value);
        cube.eulerAngles = new Vector3(0, 0, value * 360);
    }
}
