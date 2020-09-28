﻿using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class EventExample : MonoBehaviour {

    public GameObject AudioBeat;
    public TextMeshProUGUI energy;
    public TextMeshProUGUI kick;
    public TextMeshProUGUI snare;
    public TextMeshProUGUI hithat;

    public GameObject genergy;
    public GameObject gkick;
    public GameObject gsnare;
    public GameObject ghithat;

    public Material matOn;
    public Material matOff;

    public void MyCallbackEventHandler(BeatDetection.EventInfo eventInfo)
    {
        switch(eventInfo.messageInfo)
        {
            case BeatDetection.EventType.Energy:
                StartCoroutine(showText(energy, genergy));
                break;
            case BeatDetection.EventType.HitHat:
                StartCoroutine(showText(hithat, ghithat));
                break;
            case BeatDetection.EventType.Kick:
                StartCoroutine(showText(kick, gkick));
                break;
            case BeatDetection.EventType.Snare:
                StartCoroutine(showText(snare, gsnare));
                break;
        }
    }

    private IEnumerator showText(TextMeshProUGUI texto, GameObject objeto)
    {
        texto.enabled = true;
        objeto.GetComponent<Renderer>().material = matOn;
        yield return new WaitForSeconds(0.05f * 3);
        texto.enabled = false;
        objeto.GetComponent<Renderer>().material = matOff;
        yield break;
    }

    // Use this for initialization
    void Start () {
        //Register the beat callback function
        AudioBeat.GetComponent<BeatDetection>().CallBackFunction = MyCallbackEventHandler;
    }

}
