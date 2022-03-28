using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManagerScript : MonoBehaviour
{
    private int numberofSources;
    private int scale;

    [SerializeField][Range(0f, 999f)] private float _timerMax;
    private float _time;
    
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

    }
}
