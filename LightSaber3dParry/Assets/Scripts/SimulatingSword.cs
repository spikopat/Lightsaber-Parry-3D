using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SimulatingSword : MonoBehaviour {

    [SerializeField, Space(10)] Collider _fakeCollider;
    [SerializeField] Collider _realCollider;
    private Vector3 _initialLocalPosition;

    private void Start() {

        _initialLocalPosition = transform.localPosition;
    }

    //Called by event
    public void StartSwordSimulation() {

        SwitcActiveColliders();
        SwingSwords();
    }

    private void SwitcActiveColliders() {

        _fakeCollider.enabled = false;
        _realCollider.enabled = true;
    }

    private void SwingSwords() {

        DOTween.Sequence()
            .Append(transform.DOLocalMoveZ(-4f, 0.25f))
            .Append(transform.DOLocalMoveZ(_initialLocalPosition.z, 1f))
            .SetDelay(1f)
            .SetLoops(-1);
    }

}