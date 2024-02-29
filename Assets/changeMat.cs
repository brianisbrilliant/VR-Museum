using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMat : MonoBehaviour
{
    [SerializeField] private Material glass, emissive;
    [SerializeField] private bool testing = false;
    [SerializeField] private Light light;
    [SerializeField] private Transform player;      // for teleporting the player.
    [SerializeField] private Transform teleportTarget;      // for teleporting the player.
    private Renderer rend;
    private bool litUp = false;


    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<Renderer>();
        light= this.transform.GetChild(0).GetComponent<Light>();
    }

    void Update() {
        if(testing) {
            if(Input.GetKeyDown(KeyCode.L)) ToggleLight();
            if(Input.GetKeyDown(KeyCode.Alpha9)) TeleportPlayer();
        }
    }

    private void TeleportPlayer() {
        player.position = teleportTarget.position;
    }

    public void SayHello() {
        Debug.Log("Hello!");
    }

    public void ToggleLight() {
        if(litUp) {
            // turn off
            rend.material = glass;
            StartCoroutine(FadeLightTo(0));
        }
        else {
            rend.material = emissive;
            StartCoroutine(FadeLightTo(1));
        }

        litUp = !litUp;
    }

    public void ChangeLightLevel(float amount) {
        light.intensity = amount;
    }

    private IEnumerator FadeLightTo(float end = 1) {
        float start = light.intensity;
        float timer = 0;
        while(timer <= 1) {
            light.intensity = Mathf.Lerp(start, end, timer);
            timer += 0.05f;
            yield return new WaitForEndOfFrame();
        }
        // skip those pesky float issues and make it what you want it to be.
        light.intensity = end;
        
    }
}
