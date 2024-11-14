using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class MovimientodeNaveenemiga : MonoBehaviour
{
    public int life = 3;
    private Rigidbody rigibody;
    public GameObject prefabBullet;
    public Transform spawner;
    public float speedz;
    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {

    }
    void CrearBalaenemiga() {
        GameObject bullet = Instantiate(prefabBullet);
        bullet.transform.position = spawner.position;
        bullet.transform.rotation = transform.rotation;
        Invoke("Createenemy", 0.3f);
    }
    private void FixedUpdate()
    {
        rigibody.velocity = new Vector3(0,0,-speedz);
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "bala")
        {
            life = life - 1;
            if (life == 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.tag == "player")
        {
            Destroy(this.gameObject);

        }
    }
}
