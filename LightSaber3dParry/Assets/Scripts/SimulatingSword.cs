using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SimulatingSword : MonoBehaviour {

    private Vector3 _initialLocalPosition;
    [SerializeField] private ParticleSystem _hitParticle;

    private void Start() {

        _initialLocalPosition = transform.localPosition;
    }

    //Called by event
    public void StartSwordSimulation() {

        SwingSwords();
    }

    private void SwingSwords() {

        DOTween.Sequence()
            .Append(transform.DOLocalMoveZ(-4f, 0.25f))
            .Append(transform.DOLocalMoveZ(_initialLocalPosition.z, 1f))
            .SetDelay(1f)
            .SetLoops(-1);
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.layer == LayerMask.NameToLayer("LightSaber")) {
            SetHitParticlePoint(collision.contacts[0].point);
        }
    }

    private void SetHitParticlePoint(Vector3 _contactPoint) {

        _hitParticle.transform.position = _contactPoint;
        _hitParticle.Play();
    }

}