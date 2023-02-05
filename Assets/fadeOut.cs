using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers

public class fadeOut : MonoBehaviour
{
    public float seconds = 1.0f;
    private float maxSeconds;
    // Start is called before the first frame update
    void Start()
    {
        maxSeconds = seconds;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        seconds -= 0.016f;
        if(seconds < 0.0f){
            Destroy(gameObject);
        } else {
            gameObject.GetComponent<Text>().color = new Color(0.0f, 1.0f, 0.0f, seconds/maxSeconds);
        }
    }
}
