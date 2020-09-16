using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public LayerMask layerMask;
    public float radius;
    public float damage;
    
    public AudioSource hitSound;
    [SerializeField]
    ParticleSystem splatter = null;

    public void Awake()
    {
        hitSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        Collider [ ] hits = Physics.OverlapSphere(transform.position, radius, layerMask);

        foreach(Collider objDamage in hits)
        {
            Debug.Log(objDamage.name);
            hitSound.Play();
            splatter.Play();
            hits[0].GetComponent<Health>().ApplyDamage(damage);
        }
       //OnDrawGizmosSelected();
    }

    /*void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,radius);
    }*/
    
}
