using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// manages the player paddle control
/// </summary>
public class PlayerPaddle : MonoBehaviour {
	/// <summary>
	/// accept mouse movement input to move paddle along Y axis
	/// </summary>
	/// <param name="movementValue"></param>
	private void OnMove(InputValue movementValue) {
		transform.position = new Vector2(
			transform.position.x,
			Camera.main.ScreenToWorldPoint(movementValue.Get<Vector2>()).y
		);
	}
}
