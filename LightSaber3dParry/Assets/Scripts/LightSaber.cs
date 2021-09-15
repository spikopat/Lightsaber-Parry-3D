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

    [Header("Set sword's maximum Z angle"), SerializeField, Range(0f, 60f)] private float _swordMaxZAngle;
    [Space(10)]

    [SerializeField] private LightSaberTypes _lightSaberType;
    [SerializeField, Range(0.2f, 2f)] private float _angleChangeTime;

    [Space(10)]
    [SerializeField] private Transform _saberStartTransform;
    [HideInInspector] public Vector3 _saberStartPosition;

    [SerializeField] private Transform _saberEndTransform;


    private Sequence _sequence;

    private void Start() {

        _sequence = DOTween.Sequence();
        _saberStartPosition = GetSaberStartPosition();
    }

    public Vector3 GetSaberStartPosition() {

        return new Vector3(_saberStartTransform.position.x, _saberStartTransform.position.y, -5);
    }

    public Vector3 GetSaberEndPosition() {

        return new Vector3(_saberEndTransform.position.x, _saberEndTransform.position.y, -5);
    }

    public Vector3 GetSaberVector() {

        return GetSaberEndPosition() - GetSaberStartPosition();
    }

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

    }

}