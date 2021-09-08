using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour {

    [SerializeField] private Event _gEvent;
    [SerializeField] private Vector3 _simulationCamPosition;

    private void Start() {
        

    }

    public void SimulationStarted() {

        transform.DOMove(_simulationCamPosition, 1f);
    }

}