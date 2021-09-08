using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulate : MonoBehaviour {

    [SerializeField] private Event _gEvent;

    private void Start() {
        

    }

    public void StartSimulation() {

        _gEvent.Occurred(gameObject);

    }

}