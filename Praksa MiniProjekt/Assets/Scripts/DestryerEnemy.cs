using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryerEnemy : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            Destroy(other.gameObject);
        }
        
    }
}
