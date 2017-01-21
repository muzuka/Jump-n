
using UnityEngine;

public class Moveable : MonoBehaviour {

	public Transform startTransform;

	public float jumpForce;
	public float jumpTime;
	public float jumpTimeCounter;

	public bool grounded;
	public LayerMask whatIsGround;
	public bool stoppedJumping;

	public Transform groundCheck;
	public float groundCheckRadius;

	Rigidbody2D body;

	void Start () 
	{
		jumpTimeCounter = jumpTime;

		body = GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if(grounded)
			jumpTimeCounter = jumpTime;
	}

	void FixedUpdate () 
	{
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W))
		{
			if(grounded)
			{
				body.velocity = new Vector2(body.velocity.x, jumpForce);
				stoppedJumping = false;
			}
		}

		if((Input.GetMouseButton(0) || Input.GetKey(KeyCode.W)) && !stoppedJumping)
		{
			if(jumpTimeCounter > 0)
			{
				body.velocity = new Vector2(body.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if(Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.W))
		{
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}
	}

	public void restartGame ()
	{
		jumpTimeCounter = jumpTime;
		body.velocity = new Vector3();
		transform.position = startTransform.position;
	}
}
