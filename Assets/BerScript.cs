using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float accel;
    private Rigidbody rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //GetAxisRaw("Horizontal")は左右の入力(A,d,左右矢印)時に-1か1を返す
        //transform.rightはvector3(1,0,0)と々
        //ForceMode.Accelerationは質量を無視して継続的に力を加える
        rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * accel, ForceMode.Acceleration);

    }
    private void OnCollisionEnter(Collision collection)
    {
        ScoreManager.InitBonus();
    }
}
