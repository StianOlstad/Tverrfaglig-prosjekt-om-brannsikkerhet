using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFire_Script : MonoBehaviour
{
    public string ignitionObject;
    public bool fireStarted;

    [SerializeField] private ParticleSystem _particles;

    private void Start() {
        _particles.Stop();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == ignitionObject)
        {
            fireStarted = true;
            _particles.Play();
            Debug.Log("Fire Started");
        }
    }
}
