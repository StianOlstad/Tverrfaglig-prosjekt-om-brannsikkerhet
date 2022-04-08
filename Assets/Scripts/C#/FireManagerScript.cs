using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireManagerScript : MonoBehaviour
{
    [SerializeField] private int numberofSources;
    [SerializeField] private Slider _slider;
    [SerializeField][Range(0f, 999f)] private float _timerMax;
    [SerializeField] private float _time;
    private int scale;
    private float _timePercent;
    
    
}
