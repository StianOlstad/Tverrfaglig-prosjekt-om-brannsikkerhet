using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FireManagerScript : MonoBehaviour
{
    public int winScene;
    public int losScene;
    [SerializeField] private Slider _slider;
    [SerializeField] private float OnFire;
    [SerializeField]private float FireObjects;
    private float percentOfflame;
    private void Start() {
        FireObjects = GameObject.FindGameObjectsWithTag("FireSpawn").Length;
    }

    private void Update() {
        percentOfflame = OnFire / FireObjects * 100f;
        _slider.value= percentOfflame * 1f / 100f;

        if (_slider.value == 1f)
        {
            victory();
        }
    }

    public void StartedBurning(){
        OnFire += 1;
    }
    private void victory(){
        SceneManager.LoadScene(winScene);
    }
    public void death(){
        SceneManager.LoadScene(losScene);
    }
}
