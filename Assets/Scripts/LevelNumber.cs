using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LevelNumber : MonoBehaviour
    {
        public Text LevelText;
        public Game Game;

        private void Start()
        {
            LevelText.text = "Level: " + (Game.LevelIndex + 1).ToString();
        }
    }
}