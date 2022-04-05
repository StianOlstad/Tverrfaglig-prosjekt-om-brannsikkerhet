using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireManagerScript : MonoBehaviour
{
    [SerializeField] private int numberofSources;
    private int scale;
    [SerializeField] private Slider _slider;
    [SerializeField][Range(0f, 999f)] private float _timerMax;
    [SerializeField] private float _time;

    private float _timePercent;
    
    private void Start() {
        _time = _timerMax;
    }

    public void SourceActive(){
        numberofSources += 1;
    }

    private void Update() {
        if (numberofSources > 0)
        {
            _time -= 1 * Time.deltaTime;
        }
        if (numberofSources > scale)
        {
            scale = numberofSources;
            
            var percentintoTimer = (_time * 100f) / _timerMax;
            var newMaxtime = _timerMax / numberofSources;
            _time = (percentintoTimer * newMaxtime) / 100f;
        }

        _timePercent = (_time * 100f) / _timerMax;
        _slider.value = (_timePercent * 1f) / 100f;


    }
}
