using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSound : MonoBehaviour
{
    public AudioSource Blastsound;
    // Start is called before the first frame update
    void Start()
    {
        Blastsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Sphere"))
        {
            Blastsound.Play();
        }
    }
}
