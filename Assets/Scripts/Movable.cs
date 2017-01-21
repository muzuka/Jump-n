
using UnityEngine;

public class Movable : MonoBehaviour {

	bool falling;
	bool jumping;

	public float jumpForce;
	public float jumpTime;
	public float jumpTimeCounter;

	public bool grounded;
	public LayerMask whatIsGround;
	public bool stoppedJumping;

	public Transform groundCheck;
	public float groundCheckRadius;

	Rigidbody2D body;

	void Start () {
		falling = false;
		jumping = false;

		jumpTimeCounter = jumpTime;

		body = GetComponent<Rigidbody2D>();
	}

	void Update () {
		falling = body.velocity.y < 0.0f;
		jumping = body.velocity.y > 0.0f;

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if(grounded)
		{
			jumpTimeCounter = jumpTime;
		}

	}

	void FixedUpdate () {
		if(Input.GetKey(KeyCode.W) && transform.position.y < -0.6f)
			body.AddForce(new Vector2(0.0f, 75.0f));

		if(Input.GetMouseButtonDown(0))
		{
			if(grounded)
			{
				body.velocity = new Vector2(body.velocity.x, jumpForce);
				stoppedJumping = false;
			}
		}

		if(Input.GetMouseButton(0) && !stoppedJumping)
		{
			if(jumpTimeCounter > 0)
			{
				body.velocity = new Vector2(body.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}
	}
}
