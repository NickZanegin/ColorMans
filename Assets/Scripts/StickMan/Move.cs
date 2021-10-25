using UnityEngine;

public class Move : MonoBehaviour
{

	private Animator animator;
	private GwWaypoint[] waypoints;

	public const int MAX_SPEED = 10;
	public const int ACCELERATION = 5;
	private float speed = 0;
	public void StartMove(GwWaypoint[] point)
	{
		animator = GetComponent<Animator>();
		animator.SetBool("Select", false);
		animator.SetBool("Run",true);
		waypoints = point;
	}
	private void Update()
	{
		if (waypoints != null && waypoints.Length > 0)
		{
			speed = Mathf.Lerp(speed, MAX_SPEED, Time.deltaTime * ACCELERATION);
			speed = Mathf.Clamp(speed, 0, MAX_SPEED);

			transform.LookAt(waypoints[0].position);

			transform.position = Vector3.MoveTowards(transform.position, waypoints[0].position, Time.deltaTime * waypoints[0].speed * speed);

			if (Vector3.Distance(transform.position, waypoints[0].position) < 0.1f)
			{
				NextWaypoint();
			}
		}
		else
		{
			speed = 0;
		}
	}

	private void NextWaypoint()
	{
		if (waypoints.Length > 1)
		{
			GwWaypoint[] newWaypoints = new GwWaypoint[waypoints.Length - 1];

			for (int i = 1; i < waypoints.Length; i++)
			{
				newWaypoints[i - 1] = waypoints[i];
			}

			waypoints = newWaypoints;
		}
		else
		{
			waypoints = null;
		}
	}
}
