using UnityEngine;
using System.Collections.Generic;

public class Move : MonoBehaviour
{

	private Animator animator;
	public List<Point> waypoints;

	public const int MAX_SPEED = 10;
	public const int ACCELERATION = 5;
	private float speed = 0;
	public void StartMove(List<Point> point)
	{
		animator = GetComponent<Animator>();
		animator.SetBool("Select", false);
		animator.SetBool("Run",true);
		waypoints = point;
	}
	private void Update()
	{
		if (waypoints != null && waypoints.Count > 0)
		{
			speed = Mathf.Lerp(speed, MAX_SPEED, Time.deltaTime * ACCELERATION);
			speed = Mathf.Clamp(speed, 0, MAX_SPEED);

			transform.LookAt(waypoints[0].transform.localPosition);

			transform.position = Vector3.MoveTowards(transform.position, waypoints[0].transform.localPosition, Time.deltaTime * speed);

			if (Vector3.Distance(transform.position, waypoints[0].transform.localPosition) < 0.1f)
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
		if (waypoints.Count > 1)
		{
			waypoints.RemoveAt(0);
		}
		else
		{
			waypoints = null;
		}
	}
}
