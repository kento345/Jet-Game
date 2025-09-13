using UnityEngine;

public class Bullet : MonoBehaviour
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
        Destroy(gameObject, 8f);
        rb.AddForce(transform.forward * FirePw * Time.deltaTime, ForceMode.Impulse);
    }
}
