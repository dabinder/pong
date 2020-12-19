using UnityEngine;

public class AIPaddle : MonoBehaviour {
	[SerializeField] private Transform target;
	[SerializeField] private float speed;

	/// <summary>
	/// move paddle towards ball at specified speed
	/// speed may be modified to adjust difficulty
	/// </summary>
	private void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, target.position.y), step);
	}
}
