using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int move = 0;
    private AudioSource source;
    private Rounds rounds;
    private float push = 130;
    private float pull = -130;
    private KeyCode previous1;
    private KeyCode previous2;

    protected bool touch = false;
    protected int round = 1;

    public Rigidbody rb;
    public Text winText;
    public Text moveText;
    public Button ButtonStart;
    public Button ButtonExit;
    public Button ButtonTryAgain;
    public RawImage Background;
    public GameObject tutorial;
    public GameObject[] cube = new GameObject[40];

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
        
    }

    private void TaskOnClickStart()
    {
        move = 0;
        moveText.text = "Moves: " + move.ToString();
        winText.text = "";

        ButtonStart.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);
        rounds.StartRound();
        tutorial.gameObject.SetActive(false);
    }

    private void TaskOnClickTryAgain()
    {
        move = 0;
        moveText.text = "Moves: " + move.ToString();
        winText.text = "";

        ButtonTryAgain.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);
        rounds.StartRound();
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
            push += 10;
            pull -= 10;
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
            push -= 10;
            pull += 10;
            source.Play();
            winText.text = "You Lose!";
            ButtonTryAgain.gameObject.SetActive(true);
            Background.gameObject.SetActive(true);
            previous1 = KeyCode.V;
            previous2 = KeyCode.V;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }

        if (touch == true)
        {
            if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && previous1 != KeyCode.UpArrow && previous2 != KeyCode.W)
            {
                rb.AddForce(0, 0, push, ForceMode.Impulse);
                touch = false;
                move++;
                moveText.text = "Moves: " + move.ToString();
                previous1 = KeyCode.UpArrow;
                previous2 = KeyCode.W;
            }

            else if ((Input.GetKey("down") || Input.GetKey("s")) && previous1 != KeyCode.DownArrow && previous2 != KeyCode.S)
            {
                rb.AddForce(0, 0, pull, ForceMode.Impulse);
                touch = false;
                move++;
                moveText.text = "Moves: " + move.ToString();
                previous1 = KeyCode.DownArrow;
                previous2 = KeyCode.S;
            }

            else if ((Input.GetKey("left") || Input.GetKey("a")) && previous1 != KeyCode.LeftArrow && previous2 != KeyCode.A)
            {
                rb.AddForce(pull, 0, 0, ForceMode.Impulse);
                touch = false;
                move++;
                moveText.text = "Moves: " + move.ToString();
                previous1 = KeyCode.LeftArrow;
                previous2 = KeyCode.A;
            }

            else if ((Input.GetKey("right") || Input.GetKey("d")) && previous1 != KeyCode.RightArrow && previous2 != KeyCode.D)
            {
                rb.AddForce(push, 0, 0, ForceMode.Impulse);
                touch = false;
                move++;
                moveText.text = "Moves: " + move.ToString();
                previous1 = KeyCode.RightArrow;
                previous2 = KeyCode.D;
            }
        }
    }
}
// ruchome przeszkody