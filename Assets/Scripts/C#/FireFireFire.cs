using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFireFire : MonoBehaviour
{
    public GameObject _ob;
    [SerializeField] private string FireStarterObject;
    [SerializeField] private LayerMask _layer;
    private RaycastHit hitinfo;
    private RaycastHit hit;
    private bool OnFire;

    private void Start() {
        gameObject.GetComponent<ParticleSystem>().Stop();
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("1");
        if (other.gameObject.tag == FireStarterObject && OnFire == false)
        {
            beginfire();
        }
    }

    public void beginfire() {
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
    }
}
