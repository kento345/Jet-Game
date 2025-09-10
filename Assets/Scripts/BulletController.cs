using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float FirePw = 100.0f;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * FirePw * Time.deltaTime,ForceMode.Impulse);
    }
}
