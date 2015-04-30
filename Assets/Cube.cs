using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cube : MonoBehaviour {
    public List<Sphere> Spheres;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        acceleration = new Vector3(7, 0, 7);
    }

    // Update is called once per frame
    void Update() {
        // Apply force = G * m1 * m2 / r^2
        Vector3 force = acceleration;

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

        Vector3 direction = (transform.position - sphere.transform.position).normalized;

        return direction * force;
    }

    private Rigidbody rb;
    private Vector3 acceleration;
}
