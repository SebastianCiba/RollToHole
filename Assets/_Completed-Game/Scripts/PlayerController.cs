using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int move = 0;
    private AudioSource source;
    private Rounds rounds;
    private float force = 200;
    private KeyCode previous1;
    private KeyCode previous2;
    private float startTime;
    private bool runTime = true;
    private bool touch = false;
    private int round = 1;

    public Rigidbody rb;
    public Text winText;
    public Text moveText;
    public Button ButtonStart;
    public Button ButtonExit;
    public Button ButtonTryAgain;
    public RawImage Background;
    public GameObject tutorial;
    public Text timerText;

    public Vector3 startPosition = new Vector3(-2, 0.5f, 14);
    public Vector3 endPosition = new Vector3(-2, 0.5f, -3.5f);
    private float pos = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rounds = GetComponent<Rounds>();
        winText.text = "";
        moveText.text = "Moves: 0";

        Button ButtonStart1 = ButtonStart.GetComponent<Button>();
        Button ButtonExit1 = ButtonExit.GetComponent<Button>();
        Button ButtonTryAgain1 = ButtonTryAgain.GetComponent<Button>();
        source = GetComponent<AudioSource>();

        ButtonStart1.onClick.AddListener(TaskOnClickStart);
        ButtonExit1.onClick.AddListener(TaskOnClickExit);
        ButtonTryAgain1.onClick.AddListener(TaskOnClickTryAgain);

        ButtonStart.gameObject.SetActive(true);
        Background.gameObject.SetActive(true);
        tutorial.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
        moveText.gameObject.SetActive(false);
    }

    private void TaskOnClickStart()
    {
        move = 0;
        moveText.text = "Moves: " + move.ToString();
        winText.text = "";

        ButtonStart.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);
        tutorial.gameObject.SetActive(false);

        timerText.gameObject.SetActive(true);
        moveText.gameObject.SetActive(true);

        runTime = true;
        startTime = Time.time;
        touch = true;
        rb.Sleep();
        rounds.StartRound(round);
    }

    private void TaskOnClickTryAgain()
    {
        move = 0;
        moveText.text = "Moves: " + move.ToString();
        winText.text = "";

        ButtonTryAgain.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);

        runTime = true;
        startTime = Time.time;
        touch = true;
        rb.Sleep();
        rounds.StartRound(round);
    }

    private void TaskOnClickExit()
    {
        Application.Quit();
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("CollisionBox"))
        {
            source.Play();
            rb.Sleep();
            var v1 = new Vector3(0, 0, 0);
            v1 = GetComponent<Rigidbody>().position;
            float X = v1.x;
            float Z = v1.z;
            float Y = v1.y;
            X = Mathf.RoundToInt(X);
            Z = Mathf.RoundToInt(Z);
            var v2 = new Vector3(X, Y, Z);
            rb.MovePosition(v2);
            touch = true;
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            runTime = false;
            force += 20;
            source.Play();
            winText.text = "You Win!";
            ButtonStart.gameObject.SetActive(true);
            Background.gameObject.SetActive(true);
            round++;
            previous1 = KeyCode.V;
            previous2 = KeyCode.V;
        }

        if (collision.gameObject.CompareTag("Lose"))
        {
            runTime = false;
            force -= 20;
            source.Play();
            winText.text = "You Lose!";
            ButtonTryAgain.gameObject.SetActive(true);
            Background.gameObject.SetActive(true);
            previous1 = KeyCode.V;
            previous2 = KeyCode.V;
        }
    }

    void moveSpikes()
    {
        rounds.spikes.transform.position = Vector3.Lerp(startPosition, endPosition, pos);
        rounds.spikes.transform.Rotate(Vector3.forward);
        pos += 0.015f;

        if (pos >= 0.99f)
        {
            Vector3 temp = startPosition;
            startPosition = endPosition;
            endPosition = temp;
            pos = 0;
        }
    }

    private void FixedUpdate()
    {
        moveSpikes();
  
        if (runTime == true)
        {
            ChangeTime();
        }
            

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (touch == true)
        {
            if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && previous1 != KeyCode.UpArrow && previous2 != KeyCode.W)
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
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        timerText.text = "Time: " + minutes + ":" + seconds;
    }
}
//prefaby