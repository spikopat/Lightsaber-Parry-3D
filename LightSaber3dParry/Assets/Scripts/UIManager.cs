using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField] private Event gEvent;
    [SerializeField] private Transform[] _uIElements;

    private void Start() {
        

    }

    public void SimulationStarted() {

        foreach (Transform item in _uIElements) {
            item.gameObject.SetActive(false);
        }
    }

}