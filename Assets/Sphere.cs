using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {
    public int Mass { get { return _mass; } }
    public float GravityEffect { get { return _gravityEffect; } }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private const int _mass = 1;
    private float _gravityEffect = _mass * Constants.G;
}
