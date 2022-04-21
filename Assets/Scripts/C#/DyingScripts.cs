using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DyingScripts : MonoBehaviour
{
    [SerializeField] private float MaxTimeToDeath;
    [SerializeField] private Image bloodBorder;
    
    private int _burning;
    [SerializeField] private float TimeToDeath;
    [SerializeField] private float recoveryRate;
    private FireManagerScript managerScript;
    

    private void Start() {
        managerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<FireManagerScript>();
        TimeToDeath = MaxTimeToDeath;
        
        var value_a = 1f / MaxTimeToDeath * 100f;
        recoveryRate = value_a * 1f / 100f;
    }
    private void Update() {
        Debug.Log(bloodBorder.color.a);
        if (_burning > 0)
        {
            TimeToDeath -= 1f * Time.deltaTime;
            bloodBorder.color = new Color(bloodBorder.color.r, bloodBorder.color.g, bloodBorder.color.b, 
            Mathf.MoveTowards(bloodBorder.color.a, 1f, recoveryRate * Time.deltaTime));
        } else
        {
            TimeToDeath = Mathf.MoveTowards(TimeToDeath, MaxTimeToDeath, 1f * Time.deltaTime);
            bloodBorder.color = new Color(bloodBorder.color.r, bloodBorder.color.g, bloodBorder.color.b, 
            Mathf.MoveTowards(bloodBorder.color.a, 0f, recoveryRate * Time.deltaTime));
        }
        

        if (TimeToDeath <= 0f)
        {
            managerScript.death();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.CompareTag("FireWall"))
        {
            _burning -= 1;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("FireWall"))
        {
            _burning += 1;
        }
    }
    
    
}
