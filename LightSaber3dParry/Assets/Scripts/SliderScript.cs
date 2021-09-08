using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SliderBase : MonoBehaviour {

    protected abstract void OnValueChanged();
}

public class SliderScript : SliderBase {

    [SerializeField] private LightSaber _lightSaber;
    private Slider _slider;

    private void Start() {

        _slider = GetComponent<Slider>();
    }

    protected override void OnValueChanged() {
        
        _lightSaber.SetNewSaberAngle(_slider.value);
    }
}