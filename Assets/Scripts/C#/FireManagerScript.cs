using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireManagerScript : MonoBehaviour
{
    
    [SerializeField] private int OnFire;
    [SerializeField] private Slider _slider;
    private int FireObjects;
    
    private void Start() {
        FireObjects = GameObject.FindGameObjectsWithTag("FireSpawn").Length;
    }

    private void Update() {
        
    }

    public void StartedBurning(){
        OnFire += 1;
    }
}
