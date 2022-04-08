using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class StartFire_Script : MonoBehaviour
{
    public GameObject _ob;
    [SerializeField] private string FireStarterObject;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float radius;
    [SerializeField] private float _delay = 3f;

    private RaycastHit hitinfo;
    private RaycastHit hit;
    public bool OnFire;

    public static List<GameObject> gameObjectsWithinRadius = new List<GameObject>();

    private void Start() {
        _ob.gameObject.GetComponent<ParticleSystem>().Stop();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == FireStarterObject && OnFire == false)
        {
            beginfire();
        }
    }

    public void beginfire() {
        _ob.gameObject.GetComponent<ParticleSystem>().Play();
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
}
