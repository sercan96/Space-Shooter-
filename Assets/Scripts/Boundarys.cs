using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundarys : MonoBehaviour
{
    public GameObject shot;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            return;
        }
        Destroy(other.gameObject);
    }
}
