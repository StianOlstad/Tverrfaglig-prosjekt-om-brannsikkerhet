using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingScripts : MonoBehaviour
{
    [SerializeField] private float timeTodeath;
    
    private bool _burning;
    private FireManagerScript managerScript;

    private void Start() {
        managerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<FireManagerScript>();
    }
    private void Update() {
        if (_burning == true)
        {
            timeTodeath -= 1f * Time.deltaTime;
        }
        if (timeTodeath <= 0f)
        {
            managerScript.death();
        }

    }

    private void OnTriggerStay(Collider other) {
        if (other.transform.CompareTag("FireWall"))
        {
            _burning = true;
        }
    }
    
    private void OnTriggerExit(Collider other) {
        if (other.transform.CompareTag("FireWall"))
        {
            _burning = false;

        }
    }
}
