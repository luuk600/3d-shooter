using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class grenadethrowing : MonoBehaviour
{
    public float throwforce = 10f;
    public GameObject grenadeprefab;
    private float countdown = 5f;
    public float delay;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Q) && countdown <= 0)
        {
            throwGrenade();
            countdown = delay;
        }
        else
        {
            countdown = countdown -Time.deltaTime;
        }
    }
    private void throwGrenade()
    {
        GameObject grenade =Instantiate(grenadeprefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwforce, ForceMode.VelocityChange);
    }
}
