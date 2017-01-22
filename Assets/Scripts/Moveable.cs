using UnityEngine;

// Method is from Unity user "topherbwell" as described here: https://forum.unity3d.com/threads/mario-style-jumping.381906/
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
		if(stoppedJumping)
			Time.fixedDeltaTime = 0.01f;
		else
			Time.fixedDeltaTime = 0.02f;

		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(grounded)
			{
				body.velocity = new Vector2(body.velocity.x, jumpForce);
				stoppedJumping = false;
			}
		}

		if(Input.GetKey(KeyCode.Space) && !stoppedJumping)
		{
			if(jumpTimeCounter > 0)
			{
				body.velocity = new Vector2(body.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if(Input.GetKeyUp(KeyCode.Space))
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
