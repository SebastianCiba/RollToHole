using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class AudioController : MonoBehaviour {

        private bool soundIsOn = true;
        private string menuOrGame = "menu";

        public Button ButtonMusic;
        public GameObject menuMusic;
        public GameObject gameMusic;

        private void Start ()
        {
            ButtonMusic.GetComponent<Button>();
            menuMusic.GetComponent<GameObject>();
            gameMusic.GetComponent<GameObject>();
            ButtonMusic.onClick.AddListener(TaskOnClickMusic);

            soundIsOn = true;
            PlayMusic(menuOrGame);
        }

        private void TaskOnClickMusic()
        {
            soundIsOn = !soundIsOn;
            PlayMusic(menuOrGame);
        }

        public void PlayMusic( string state)
        {
            menuOrGame = state;
            if (soundIsOn)
            {
                switch (menuOrGame)
                {
                    case "menu":
                        gameMusic.gameObject.SetActive(false);
                        menuMusic.gameObject.SetActive(true);
                        break;
                    case "game":
                        menuMusic.gameObject.SetActive(false);
                        gameMusic.gameObject.SetActive(true);
                        break;
                }
            }

            else
            {
                gameMusic.gameObject.SetActive(false);
                menuMusic.gameObject.SetActive(false);
            }
        }
    }
}
