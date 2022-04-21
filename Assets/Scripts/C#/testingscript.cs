using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingscript : MonoBehaviour
{
    [SerializeField] private GameObject[] _ALLFIRESPAWNS;
    private void Start() {
        Application.targetFrameRate = 30;
        _ALLFIRESPAWNS = GameObject.FindGameObjectsWithTag("FireSpawn");
    }
}
