using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class RocketController : MonoBehaviour
{
    [SerializeField] private float FirePw = 100.0f;

    Rigidbody rb;

    private SliderScript script;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject player = GameObject.Find("Player");
        script = player.GetComponent<SliderScript>();
    }

    void Update()
    {
        if (script.lockedTarget != null)
        {
            Focus();
            Rocket();
        }
        else if(script.lockedTarget == null) 
        {
            rb.AddForce(transform.forward * FirePw * Time.deltaTime, ForceMode.Impulse);
        }
    }
   void Focus()
    {
        var toTarget = (script.lockedTarget.transform.position - this.transform.position).normalized;
        var foward = transform.forward;

        var dot = Vector3.Dot(foward, toTarget);
        if (0.999f < dot) { return; }

        var radian = Mathf.Acos(dot);

        var cross = Vector3.Cross(foward, toTarget);
        radian *= (cross.y / Mathf.Abs(cross.y));

        transform.rotation *= Quaternion.Euler(0, Mathf.Rad2Deg * radian, 0);
    }
    void Rocket()
    {
        var dist = script.lockedTarget.transform.position - transform.position;
        var length = Mathf.Sqrt((dist.x * dist.x) + (dist.y * dist.y) + (dist.z * dist.z));

        var vector = dist / length;

        vector *= (length / 20.0f);

        transform.position += vector;
    }
}
