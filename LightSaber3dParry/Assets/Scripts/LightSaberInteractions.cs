using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaberInteractions : MonoBehaviour {

    [SerializeField] private Event _canCollideEvent;
    [SerializeField] private Event _cantCollideEvent;
    [SerializeField] private ParticleSystem _hitParticle;

    private void Start() {
        

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

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.layer == LayerMask.NameToLayer("LightSaber")) {
            Debug.Log("Çarptý");
            SetHitParticlePoint(collision.contacts[0].point);            
        }
    }

    private void SetHitParticlePoint(Vector3 _contactPoint) {

        _hitParticle.transform.position = _contactPoint;
        _hitParticle.Play();
    }
}