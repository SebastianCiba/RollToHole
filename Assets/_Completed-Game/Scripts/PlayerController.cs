//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float push = 140;
    private float pull = -140;
    private bool touch = false;
    private int move = 0;
    private int round = 0;
    private AudioSource source;

    public Rigidbody rb;
    public Text winText;
    public Text moveText;
    public Button ButtonStart;
    public RawImage Background;
    public GameObject exit;

    //public List<Vector3> roundOne = new List<Vector3>();
    //public List<GameObject> cubes = new List<GameObject>();
    public GameObject[] cube = new GameObject[40];

    void Start()
    {
        //initObjectRound();
        rb = GetComponent<Rigidbody>();
        rb.Sleep();
        winText.text = "";
        moveText.text = "Moves: 0";

        Button ButtonStart1 = ButtonStart.GetComponent<Button>();
        Background.gameObject.SetActive(true);


        ButtonStart1.onClick.AddListener(TaskOnClickStart);
        ButtonStart.gameObject.SetActive(true);
        Background.gameObject.SetActive(true);
        source = GetComponent<AudioSource>();
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

    void RoundOne()
    {
        for (int i = 0; i < 5; i++)
        {
            cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube[i].tag = "CollisionBox";
            cube[i].name = "cube_" + i;
        }

        cube[0].transform.position = new Vector3(4, 0.5f, 0);
        cube[1].transform.position = new Vector3(-6, 0.5f, 0);
        cube[2].transform.position = new Vector3(1, 0.5f, -9);
        cube[3].transform.position = new Vector3(0, 0.5f, -13);
        cube[4].transform.position = new Vector3(3, 0.5f, -14);

        rb.transform.position = new Vector3(0, 1, 0);
        //rb.Sleep();
        touch = true;
    }

    void RoundTwo()
    {
        push += 10;
        pull -= 10;
        exit.transform.position = new Vector3(0, 0, 3);

        for (int i = 0; i < 23; i++)
        {
            cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube[i].tag = "CollisionBox";
            cube[i].name = "cube_" + i;
        }

        cube[0].transform.position = new Vector3(5, 0.5f, 0);
        cube[1].transform.position = new Vector3(4, 0.5f, -3);
        cube[2].transform.position = new Vector3(0, 0.5f, -2);
        cube[3].transform.position = new Vector3(1, 0.5f, 2);
        cube[4].transform.position = new Vector3(-2, 0.5f, 1);
        cube[5].transform.position = new Vector3(-1, 0.5f, -4);
        cube[6].transform.position = new Vector3(3, 0.5f, -6);
        cube[7].transform.position = new Vector3(-4, 0.5f, -5);
        cube[8].transform.position = new Vector3(-3, 0.5f, 2);
        cube[9].transform.position = new Vector3(-6, 0.5f, 1);
        cube[10].transform.position = new Vector3(-5, 0.5f, 3);
        cube[11].transform.position = new Vector3(-8, 0.5f, 2);
        cube[12].transform.position = new Vector3(-7, 0.5f, 5);
        cube[13].transform.position = new Vector3(3, 0.5f, 4);
        cube[14].transform.position = new Vector3(2, 0.5f, -8);
        cube[15].transform.position = new Vector3(2, 0.5f, 6);
        cube[16].transform.position = new Vector3(6, 0.5f, 5);
        cube[17].transform.position = new Vector3(-7, 0.5f, 0);
        cube[18].transform.position = new Vector3(-5, 0.5f, -1);
        cube[19].transform.position = new Vector3(-4, 0.5f, -3);
        cube[20].transform.position = new Vector3(-6, 0.5f, -4);
        cube[21].transform.position = new Vector3(-8, 0.5f, -8);
        cube[22].transform.position = new Vector3(-3, 0.5f, -9);

        rb.transform.position = new Vector3(0, 1, 0);
        rb.Sleep();
        touch = true;
    }

    void RoundThree()
    {
        push += 10;
        pull -= 10;
        exit.transform.position = new Vector3(0, 0, 0);
        for (int i = 0; i < 32; i++)
        {
            cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube[i].tag = "CollisionBox";
            cube[i].name = "cube_" + i;
        }

        cube[0].transform.position = new Vector3(0, 0.5f, -2);
        cube[1].transform.position = new Vector3(6, 0.5f, -1);
        cube[2].transform.position = new Vector3(5, 0.5f, -4);
        cube[3].transform.position = new Vector3(-5, 0.5f, -3);
        cube[4].transform.position = new Vector3(-4, 0.5f, 3);
        cube[5].transform.position = new Vector3(-6, 0.5f, 2);
        cube[6].transform.position = new Vector3(-5, 0.5f, 8);
        cube[7].transform.position = new Vector3(-8, 0.5f, 7);
        cube[8].transform.position = new Vector3(-7, 0.5f, -6);
        cube[9].transform.position = new Vector3(-4, 0.5f, -5);
        cube[10].transform.position = new Vector3(-5, 0.5f, -8);
        cube[11].transform.position = new Vector3(-10, 0.5f, -7);
        cube[12].transform.position = new Vector3(-9, 0.5f, 10);
        cube[13].transform.position = new Vector3(4, 0.5f, 9);

        cube[14].transform.position = new Vector3(-4, 0.5f, 8);
        cube[15].transform.position = new Vector3(9, 0.5f, 8);
        cube[16].transform.position = new Vector3(-1, 0.5f, 6);
        cube[17].transform.position = new Vector3(1, 0.5f, 6);
        cube[18].transform.position = new Vector3(-4, 0.5f, 5);
        cube[19].transform.position = new Vector3(5, 0.5f, 5);
        cube[20].transform.position = new Vector3(0, 0.5f, 4);
        cube[21].transform.position = new Vector3(9, 0.5f, 3);
        cube[22].transform.position = new Vector3(2, 0.5f, 2);
        cube[23].transform.position = new Vector3(7, 0.5f, 1);
        cube[24].transform.position = new Vector3(-2, 0.5f, 0);
        cube[25].transform.position = new Vector3(2, 0.5f, 0);
        cube[26].transform.position = new Vector3(8, 0.5f, -3);
        cube[27].transform.position = new Vector3(7, 0.5f, -5);
        cube[28].transform.position = new Vector3(1, 0.5f, -6);
        cube[29].transform.position = new Vector3(-3, 0.5f, -9);
        cube[30].transform.position = new Vector3(6, 0.5f, -9);

        cube[31].transform.position = new Vector3(3, 0.5f, -11);

        rb.transform.position = new Vector3(0, 1, 0);
        rb.Sleep();
        touch = true;
    }

    void TaskOnClickStart()
    {
        round++;
        move = 0;
        for (int i = 0; i < cube.Length ; i++)
        {
            Destroy(cube[i]);
        }
        winText.text = "";
        
        ButtonStart.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);
        rb.AddForce(0, 30, 0, ForceMode.Impulse);
        //rb.Sleep();
        //touch = true;
        switch (round)
        {
            case 1:
                RoundOne();
                break;
            case 2:
                RoundTwo();
                break;
            case 3:
                RoundThree();
                break;
            default:
                Background.gameObject.SetActive(true);
                break;
        }
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
            source.Play();
            winText.text = "You Win!";
            ButtonStart.gameObject.SetActive(true);
            Background.gameObject.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Lose"))
        {
            source.Play();
            winText.text = "You Lose!";
            ButtonStart.gameObject.SetActive(true);
            Background.gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (touch == true)
        {
            if (Input.GetKey("up") || Input.GetKey("w"))
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

    // collision with obj with "Is Trigger" is checked
    //void OnTriggerEnter(Collider other)
    //{

    //}

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 50), moveText.text.ToString());
        //    GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), "Top-right");
        //    GUI.Box(new Rect(0, Screen.height - 50, 100, 50), "Bottom-left");
        //    GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 100, 50), "Bottom right");
    }
}

//teleporty
//dźwignie z przejściem
//przejścia w jedną stronę
//przeszkody ruchome
//pola z kolcami