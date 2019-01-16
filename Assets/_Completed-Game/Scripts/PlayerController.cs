using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private int move = 0;
        private Rounds rounds;
        private float force = 200;
        private KeyCode previous1;
        private KeyCode previous2;
        private float startTime;
        private bool runTime = true;
        private bool touch = false;
        private int round = 1;
        private float actualPosition = 0;
        private Vector3 startPosition = new Vector3(-2, 0.5f, 14);
        private Vector3 endPosition = new Vector3(-2, 0.5f, -3.5f);
        private AudioSource hitSound;

        public Rigidbody rb;
        public Text winText;
        public Text moveText;
        public Button ButtonStart;
        public Button ButtonExit;
        public Button ButtonTryAgain;
        public RawImage Background;
        public GameObject tutorial;
        public Text timerText;
        public Text roundText;
        public new AudioController audio;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rounds = GetComponent<Rounds>();
            audio = GetComponent<AudioController>();
            ButtonStart.GetComponent<Button>();
            ButtonExit.GetComponent<Button>();
            ButtonTryAgain.GetComponent<Button>();
            hitSound = GetComponent<AudioSource>();

            ButtonStart.onClick.AddListener(TaskOnClickStart);
            ButtonExit.onClick.AddListener(TaskOnClickExit);
            ButtonTryAgain.onClick.AddListener(TaskOnClickTryAgain);

            ButtonStart.gameObject.SetActive(true);
            Background.gameObject.SetActive(true);
            tutorial.gameObject.SetActive(true);
            timerText.gameObject.SetActive(false);
            moveText.gameObject.SetActive(false);
            roundText.gameObject.SetActive(false);

            winText.text = "";
            moveText.text = "Moves: 0";
            audio.PlayMusic("menu");
        }

        private void TaskOnClickStart()
        {
            ButtonStart.gameObject.SetActive(false);
            Background.gameObject.SetActive(false);
            tutorial.gameObject.SetActive(false);

            timerText.gameObject.SetActive(true);
            moveText.gameObject.SetActive(true);
            roundText.gameObject.SetActive(true);

            audio.PlayMusic("game");
            TaskOnClickTryAgain();
        }

        private void TaskOnClickTryAgain()
        {
            move = 0;
            moveText.text = "Moves: " + move.ToString();
            winText.text = "";
            roundText.text = "Round: " + round + " / 7";

            ButtonTryAgain.gameObject.SetActive(false);
            Background.gameObject.SetActive(false);
            moveText.gameObject.SetActive(true);
            audio.PlayMusic("game");

            runTime = true;
            startTime = Time.time;
            touch = true;
            rb.Sleep();
            rb.transform.position = new Vector3(0, 1, 0);
            rounds.StartRound(round);
        }

        private static void TaskOnClickExit()
        {
            Application.Quit();
        }

        private void TaskOnClickButtonRound1()
        {
            round = 1;
            TaskOnClickTryAgain();
            rounds.StartRound(round);
            ButtonStart.gameObject.SetActive(false);
        }

        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.CompareTag("CollisionBox"))
            {
                hitSound.Play();
                rb.Sleep();
                var v1 = GetComponent<Rigidbody>().position;
                var x = v1.x;
                var z = v1.z;
                var y = v1.y;
                x = Mathf.RoundToInt(x);
                z = Mathf.RoundToInt(z);
                var v2 = new Vector3(x, y, z);
                rb.MovePosition(v2);
                touch = true;
            }

            else if (collision.gameObject.CompareTag("Finish"))
            {
                runTime = false;
                hitSound.Play();
                round++;
                winText.text = "Well done!";
                ButtonStart.gameObject.SetActive(true);
                Background.gameObject.SetActive(true);
                moveText.gameObject.SetActive(false);
                audio.PlayMusic("menu");
                force += 20;
                previous1 = KeyCode.V;
                previous2 = KeyCode.V;
            }

            else if (collision.gameObject.CompareTag("Lose"))
            {
                runTime = false;
                hitSound.Play();
                winText.text = "You Lose!";
                ButtonTryAgain.gameObject.SetActive(true);
                Background.gameObject.SetActive(true);
                moveText.gameObject.SetActive(false);
                audio.PlayMusic("menu");
                force -= 20;
                previous1 = KeyCode.V;
                previous2 = KeyCode.V;
            }
        }

        private void MoveSpikes()
        {
            rounds.spikes.transform.position = Vector3.Lerp(startPosition, endPosition, actualPosition);
            rounds.spikes.transform.Rotate(Vector3.forward);
            actualPosition += 0.015f;

            if (!(actualPosition >= 0.99f)) return;
            var temp = startPosition;
            startPosition = endPosition;
            endPosition = temp;
            actualPosition = 0;
        }

        private void FixedUpdate()
        {
            MoveSpikes();
  
            if (runTime == true)
            {
                ChangeTime();
            }
            

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (touch == false) return;
            {
                if ((Input.GetKey("up") || Input.GetKey("w")) && previous1 != KeyCode.UpArrow && previous2 != KeyCode.W)
                {
                    rb.AddForce(0, 0, force, ForceMode.Impulse);
                    touch = false;
                    move++;
                    moveText.text = "Moves: " + move.ToString();
                    previous1 = KeyCode.UpArrow;
                    previous2 = KeyCode.W;
                }

                else if ((Input.GetKey("down") || Input.GetKey("s")) && previous1 != KeyCode.DownArrow && previous2 != KeyCode.S)
                {
                    rb.AddForce(0, 0, -force, ForceMode.Impulse);
                    touch = false;
                    move++;
                    moveText.text = "Moves: " + move.ToString();
                    previous1 = KeyCode.DownArrow;
                    previous2 = KeyCode.S;
                }

                else if ((Input.GetKey("left") || Input.GetKey("a")) && previous1 != KeyCode.LeftArrow && previous2 != KeyCode.A)
                {
                    rb.AddForce(-force, 0, 0, ForceMode.Impulse);
                    touch = false;
                    move++;
                    moveText.text = "Moves: " + move.ToString();
                    previous1 = KeyCode.LeftArrow;
                    previous2 = KeyCode.A;
                }

                else if ((Input.GetKey("right") || Input.GetKey("d")) && previous1 != KeyCode.RightArrow && previous2 != KeyCode.D)
                {
                    rb.AddForce(force, 0, 0, ForceMode.Impulse);
                    touch = false;
                    move++;
                    moveText.text = "Moves: " + move.ToString();
                    previous1 = KeyCode.RightArrow;
                    previous2 = KeyCode.D;
                }
            }
        
        }

        private void ChangeTime()
        {
            var t = Time.time - startTime;
            var minutes = ((int)t / 60).ToString();
            var seconds = (t % 60).ToString("f0");
            timerText.text = "Time: " + minutes + ":" + seconds;
        }
    }
}