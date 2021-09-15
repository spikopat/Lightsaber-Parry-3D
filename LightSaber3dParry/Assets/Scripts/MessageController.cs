using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class MessageController : MonoBehaviour {

    private TextMeshProUGUI _message;

    void Start() {

        _message = GetComponent<TextMeshProUGUI>();
    }

    //Called by CanCollideEvent
    public void SetMessage(string message) {
        _message.text = message;
        Invoke("TurnOff", 0.5f);
    }

    //Called by CanCollideEvent
    public void TextBounceAnim() {
        transform.localScale = new Vector3(1, 1, 1);
    }

    //Called by CantCollideEvent
    public void TurnOff() {
        transform.localScale = Vector3.zero;
    }

}