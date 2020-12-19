using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour {
	[SerializeField] private float speed;
	[SerializeField] private UnityEvent<Scorer> OnScore;

	private Rigidbody2D _rb;
	private bool _launched;

	/// <summary>
	/// locate rigidbody component for ball
	/// </summary>
	private void Awake() {
		_rb = GetComponent<Rigidbody2D>();
	}

	/// <summary>
	/// listen for mouse click to start ball moving
	/// </summary>
	/// <param name="click">left mouse click input</param>
	private void OnLaunch(InputValue click) {
		if (_launched) return;
		_launched = true;
		float x = Random.Range(0, 2) == 0 ? -1 : 1;
		float y = Random.Range(0, 2) == 0 ? -1 : 1;
		_rb.velocity = new Vector2(x, y).normalized * speed;
	}

	/// <summary>
	/// reset ball to start position after scoring
	/// </summary>
	public void Reset() {
		_launched = false;
		_rb.velocity = Vector2.zero;
		transform.position = Vector2.zero;
	}

	/// <summary>
	/// handle ball passing into a goal
	/// </summary>
	/// <param name="other">goal trigger (player or AI)</param>
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(Tags.PLAYER_GOAL)) {
			OnScore?.Invoke(Scorer.AI);
		} else if (other.CompareTag(Tags.AI_GOAL)) {
			OnScore?.Invoke(Scorer.Player);
		}
	}
}
