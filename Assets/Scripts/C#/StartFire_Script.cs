using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class StartFire_Script : MonoBehaviour
{
    public string ignitionObject;
    public bool fireStarted;
    public GameObject[] firePos;
    [SerializeField] private float fireSpreadRate;

    public int firesStarted;

    private ParticleSystem _particles;

    private void Start() {
        firePos = GameObject.FindGameObjectsWithTag("FireSpawn");
        firePos = firePos.OrderBy((d) => (d.transform.position - transform.position).sqrMagnitude).ToArray();
        for (int i = 0; i < firePos.Length; i++)
        {
            firePos[i].SetActive(false);
        }

        _particles = gameObject.GetComponent<ParticleSystem>();
        _particles.Stop();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == ignitionObject && fireStarted == false)
        {
            
            _particles.Play();
            Debug.Log("Fire Started");
            StartCoroutine("FireSpread");
        }
    }

    private IEnumerator FireSpread(){
        if (fireStarted == false)
        {
            fireStarted = true;
            yield return new WaitForSeconds(fireSpreadRate);
        }
        
        for (int i = 0; i < firePos.Length; i++)
        {
            if (firePos[i].activeSelf == false)
            {
                firePos[i].SetActive(true);
            }else
            {
                yield return new WaitForSeconds(0);
            }
            
            yield return new WaitForSeconds(fireSpreadRate);
        }
        Debug.Log("1");
        StopCoroutine("FireSpread");
    }
}
