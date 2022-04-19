using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireManagerScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float OnFire;
    [SerializeField]private float FireObjects;

    public float percentOfflame;
    private void Start() {
        FireObjects = GameObject.FindGameObjectsWithTag("FireSpawn").Length;
    }

    private void Update() {
        percentOfflame = OnFire / FireObjects * 100f;
        _slider.value= percentOfflame * 1f / 100f;
    }

    public void StartedBurning(){
        OnFire += 1;
    }
}
