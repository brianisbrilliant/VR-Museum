using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levertest : MonoBehaviour
{
    public void ChangeScale(float value) {
        Debug.Log("<color=red>value = " + value + "</color>");
        this.transform.localScale = new Vector3(1, value, 1);
    }
}
