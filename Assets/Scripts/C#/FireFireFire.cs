using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFireFire : MonoBehaviour
{   
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _delay = 3f;
    [SerializeField] private float radius = 2f;
    public bool OnFire;
    


    private void Start() {
        gameObject.GetComponent<ParticleSystem>().Stop();
    }

    public void beginfire() {
        gameObject.GetComponent<ParticleSystem>().Play();
        OnFire = true;
        StartCoroutine("FireSpreadTimer");

    }

    private IEnumerator FireSpreadTimer(){
        yield return new WaitForSeconds(_delay);
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius, _layer);
        foreach (var item in hitColliders)
        {
            if (item.gameObject.GetComponent<FireFireFire>().OnFire == false)
            {
                item.gameObject.GetComponent<FireFireFire>().beginfire();
            }
        }

        yield break;
    }

    /*public void beginfire() {
        Debug.Log("2");
        gameObject.GetComponent<ParticleSystem>().Play();
        OnFire = true;
        Physics.SphereCast(transform.position, 15f, transform.position, out hit, 0.0f, _layer);
        _ob = hit.collider.transform.gameObject;
        if (hit.collider.GetComponent<GameObject>().tag == "Respawn")
        {
            Debug.Log("3");
            hit.collider.GetComponent<GameObject>().GetComponent<FireFireFire>().beginfire();
            
        }
    }*/
}
