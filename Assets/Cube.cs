using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cube : MonoBehaviour {
    public List<Sphere> Spheres;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        // Apply force = G * m1 * m2 / r^2
        Vector3 force = Vector3.zero;

        foreach (Sphere sphere in Spheres) {
            force += GetForceFromSphere(sphere);
        }

        Vector3 forceThisFrame = force * Time.deltaTime;
        rb.AddForce(forceThisFrame, ForceMode.VelocityChange);

        Debug.Log(forceThisFrame);
    }

    private Vector3 GetForceFromSphere(Sphere sphere) {
        float distanceToSphereCenter = Vector3.Distance(transform.position, sphere.transform.position);
        float force = -sphere.GravityEffect / distanceToSphereCenter;

        // Shouldn't the part in ( ) be normalized? Currently with my other values, normalizing it makes the object move way too slowly.
        return (transform.position - sphere.transform.position) * force;
    }

    private Rigidbody rb;
}
