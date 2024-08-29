using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
        public void MainMenuRestart()
    {
        GameOverScreen.SetActive(false);
    }
}
