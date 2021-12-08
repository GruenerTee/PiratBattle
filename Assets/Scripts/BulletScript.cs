
using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

    private void Awake()
    {
        Destroy( gameObject, 5);
        //this.GetComponent<Rigidbody>().AddForce(transform.forward*10000);
    }
}
