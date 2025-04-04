using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;

	void Start()
    {
		rb = GetComponent<Rigidbody>();
	}
	// Attention, on utilise FixedUpdate() et pas Update() !
    void FixedUpdate()
	{
		rb.AddForce(speed * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")));
	}
}