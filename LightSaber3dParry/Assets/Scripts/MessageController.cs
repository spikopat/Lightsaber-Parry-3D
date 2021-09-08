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

    //Called by event
    public void SetMessage(string message) {

        _message.text = message;
    }

    //Called by event
    public void TextBounceAnim() {

        transform.DOScale(1, 0.75f).SetEase(Ease.OutBounce);
    }

    //Called by event
    public void TurnOff() {

        transform.DOScale(0, 0.25f);
    }

}