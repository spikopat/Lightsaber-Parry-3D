using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class LightSaberBase : MonoBehaviour{

    public abstract void SetNewSaberAngle(float _sliderValue);

    public abstract void RotateLightSaber(Vector3 _newZAngle);

    public enum LightSaberTypes : byte {
        Red,
        Yellow
    }
}

public class LightSaber : LightSaberBase {

    [SerializeField] private Event _canCollideEvent;
    [SerializeField] private Event _cantCollideEvent;
    [Header("Set sword's maximum Z angle"), SerializeField, Range(0f, 60f)] private float _swordMaxZAngle;
    [SerializeField] private LightSaberTypes _lightSaberType;
    [SerializeField, Range(0.2f, 2f)] private float _angleChangeTime;
    [SerializeField] Collider _fakeCollider;

    private Sequence _sequence;

    public override void SetNewSaberAngle(float _sliderValue) {

        float _newZAngle = _sliderValue * _swordMaxZAngle * ((_lightSaberType == LightSaberTypes.Red) ? -1 : 1);
        Vector3 _newRotationValue = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _newZAngle);
        RotateLightSaber(_newRotationValue);
    }

    public override void RotateLightSaber(Vector3 _newRotationValue) {

        if (_sequence.IsPlaying())
            _sequence.Kill();

        _sequence = DOTween.Sequence()
            .Append(transform.DOLocalRotate(_newRotationValue, _angleChangeTime));
            //.OnUpdate(() => {
            //    CheckCollision();
            //});
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("LightSaber")) {
            _canCollideEvent.Occurred(gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("LightSaber")) {
            _cantCollideEvent.Occurred(gameObject);
        }
    }

    private void Start() {

        _sequence = DOTween.Sequence();
    }

}