using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int move = 0;
    private AudioSource source;
    private Rounds rounds;

    public float push = 130;
    protected float pull = -130;
    protected bool touch = false;
    protected int round = 1;

    public Rigidbody rb;
    public Text winText;
    public Text moveText;
    public Button ButtonStart;
    public Button ButtonExit;
    public Button ButtonTryAgain;
    public RawImage Background;

    //public List<Vector3> roundOne = new List<Vector3>();
    //public List<GameObject> cubes = new List<GameObject>();
    public GameObject[] cube = new GameObject[40];

    void Start()
    {
        //initObjectRound();
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
    //kamilowe rzeczy
    //void initObjectRound()
    //{
    //    roundOne.Add(new Vector3(4, 0.5f, 0));
    //    roundOne.Add(new Vector3(-6, 0.5f, 0));
    //    roundOne.Add(new Vector3(1.5f, 0.5f, -8.69f));
    //    roundOne.Add(new Vector3(0, 0.5f, -13.5f));
    //    roundOne.Add(new Vector3(3, 0.5f, -14.5f));
    //    GameObject gameObject = GameObject.Find("Cubes");
    //    MeshFilter temp = gameObject.AddComponent<MeshFilter>();
    //    temp.mesh = new Mesh();
    //    //foreach(var temp in roundOne){
    //   //     gameObject.AddComponent("Cube");
    //       // temporary.MovePosition(temp);
    //  //  }
    //}   
    void TaskOnClickStart()
    {
        move = 0;
        moveText.text = "Moves: " + move.ToString();
        winText.text = "";

        ButtonStart.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);
        rounds.StartRound();
    }

    void TaskOnClickTryAgain()
    {
        move = 0;
        moveText.text = "Moves: " + move.ToString();
        winText.text = "";

        ButtonTryAgain.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);
        rounds.StartRound();
    }

    void TaskOnClickExit()
    {
        Application.Quit();
    }


    void OnCollisionEnter(Collision collision)
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
            pull += 10;
            source.Play();
            winText.text = "You Win!";
            ButtonStart.gameObject.SetActive(true);
            Background.gameObject.SetActive(true);
            round++;
        }

        if (collision.gameObject.CompareTag("Lose"))
        {
            push -= 10;
            pull -= 10;
            source.Play();
            winText.text = "You Lose!";
            ButtonTryAgain.gameObject.SetActive(true);
            Background.gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }

        if (touch == true)
        {
            if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
            {
                rb.AddForce(0, 0, push, ForceMode.Impulse);
                touch = false;
                move++;
                moveText.text = "Moves: " + move.ToString();
            }

            else if (Input.GetKey("down") || Input.GetKey("s"))
            {
                rb.AddForce(0, 0, pull, ForceMode.Impulse);
                touch = false;
                move++;
                moveText.text = "Moves: " + move.ToString();
            }

            else if (Input.GetKey("left") || Input.GetKey("a"))
            {
                rb.AddForce(pull, 0, 0, ForceMode.Impulse);
                touch = false;
                move++;
                moveText.text = "Moves: " + move.ToString();
            }

            else if (Input.GetKey("right") || Input.GetKey("d"))
            {
                rb.AddForce(push, 0, 0, ForceMode.Impulse);
                touch = false;
                move++;
                moveText.text = "Moves: " + move.ToString();
            }

        }
    }
}

//teleporty
//dźwignie z przejściem
//przejścia w jedną stronę
//przeszkody ruchome
//pola z kolcami