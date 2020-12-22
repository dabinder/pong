using TMPro;
using UnityEngine;

/// <summary>
/// runs the game and handles scoring updates
/// </summary>
public class GameManager : MonoBehaviour {
	[SerializeField]
	private GameObject ball;

	[SerializeField]
	private TextMeshProUGUI playerScoreText, aiScoreText;

	private int _playerScore, _aiScore;

	/// <summary>
	/// handle goal scored
	/// </summary>
	/// <param name="scorer">indicate whether player or AI has scored</param>
	private void Score(Scorer scorer) {
		switch (scorer) {
			case Scorer.Player:
				_playerScore++;
				playerScoreText.text = _playerScore.ToString();
				break;

			case Scorer.AI:
				_aiScore++;
				aiScoreText.text = _aiScore.ToString();
				break;
		}

		ball.GetComponent<Ball>().Reset();
	}
}
