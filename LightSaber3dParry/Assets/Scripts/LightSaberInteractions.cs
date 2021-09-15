using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaberInteractions : MonoBehaviour {

    [SerializeField] private Event _canCollideEvent;
    [SerializeField] private Event _cantCollideEvent;

    [SerializeField] private LightSaber lightSaber1;
    [SerializeField] private LightSaber lightSaber2;

    private Vector3 intersectionPoint;

    private void Start() {


    }

    //Called by event
    public void CheckIntersection() {

        if (
            LineLineIntersection(out intersectionPoint,
                lightSaber1.GetSaberStartPosition(),
                lightSaber1.GetSaberVector(),
                lightSaber2.GetSaberStartPosition(),
                lightSaber2.GetSaberVector())
        ) {
            _canCollideEvent.Occurred(gameObject);
        } else {
            _cantCollideEvent.Occurred(gameObject);
        }
    }

    //Is swords intersecting on 2D axis
    public bool LineLineIntersection(out Vector3 intersection, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2) {

        Vector3 lineVec3 = linePoint2 - linePoint1;
        Vector3 crossVec1and2 = Vector3.Cross(lineVec1, lineVec2);
        Vector3 crossVec3and2 = Vector3.Cross(lineVec3, lineVec2);

        float planarFactor = Vector3.Dot(lineVec3, crossVec1and2);

        //Is coplanar, and not parallel
        if (Mathf.Abs(planarFactor) < 0.0001f && crossVec1and2.sqrMagnitude > 0.0001f) {
            float s = Vector3.Dot(crossVec3and2, crossVec1and2) / crossVec1and2.sqrMagnitude;
            intersection = linePoint1 + (lineVec1 * s);
            intersection = new Vector3(intersection.x, intersection.y, -5);

            Vector3 newRay = intersection - linePoint1;
            Vector3 newRay2 = intersection - linePoint2;

            if (newRay.magnitude < lineVec1.magnitude && newRay2.magnitude < linePoint2.magnitude)
                return true;

            intersection = Vector3.zero;
            return false;

        } else {
            intersection = Vector3.zero;
            return false;
        }
    }

}