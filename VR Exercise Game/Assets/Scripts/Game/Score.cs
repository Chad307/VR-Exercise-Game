using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Score : MonoBehaviour
    {
        public int score = 0;

        public Text scoreText;

        private void Awake()
        {
            StartGameScore();
        }

        // Use this for initialization
        public void StartGameScore()
        {
            scoreText.text = "Score: 0";
            score = 0;
        }

        public void AddScore()
        {
            score++;
            scoreText.text = "Score: " + score;
        }
    }
}
