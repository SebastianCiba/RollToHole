using UnityEngine;

namespace Assets.Scripts
{
    public class Rounds : MonoBehaviour
    {
        public GameObject exit;
        public GameObject spikes;
        public UnityEngine.UI.RawImage Win;
        public Material Material1;
        public Material Material2;
        public Material Material3;
        public Material Material4;
        public Material Material5;
        public Material Material6;
        public Material Material7;
        public PlayerController playerController;
        public GameObject[] cube;

        public void StartRound(int round)
        {
            spikes.GetComponent<Renderer>().material.color = Color.red;

            foreach (var t in cube)
            {
                Destroy(t);
            }

            //round = 4;

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
                case 4:
                    RoundFour();
                    break;
                case 5:
                    RoundFive();
                    break;
                case 6:
                    RoundSix();
                    break;
                case 7:
                    RoundSeven();
                    break;
                default:
                    Win.gameObject.SetActive(true);
                    break;
            }
        }

        public void RoundOne()
        {
            cube = new GameObject[5];
            playerController.rb.transform.position = new Vector3(0, 1, 0);

            for (var i = 0; i < 5; i++)
            {
                cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube[i].tag = "CollisionBox";
                cube[i].name = "cube_" + i;
                cube[i].GetComponent<MeshRenderer>().material = Material1;
            }

            cube[0].transform.position = new Vector3(4, 0.5f, 0);
            cube[1].transform.position = new Vector3(-6, 0.5f, 0);
            cube[2].transform.position = new Vector3(1, 0.5f, -9);
            cube[3].transform.position = new Vector3(0, 0.5f, -13);
            cube[4].transform.position = new Vector3(3, 0.5f, -14);
        }

        public void RoundTwo()
        {
            cube = new GameObject[11];
            exit.transform.position = new Vector3(0, 0, 0);
            exit.transform.rotation = Quaternion.Euler(0, 180, 0);
            playerController.rb.transform.position = new Vector3(0, 1, 0);

            for (var i = 0; i < 11; i++)
            {
                cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube[i].tag = "CollisionBox";
                cube[i].name = "cube_" + i;
                cube[i].GetComponent<MeshRenderer>().material = Material2;
            }

            cube[0].transform.position = new Vector3(2, 0.5f, 0);
            cube[1].transform.position = new Vector3(1, 0.5f, -5);
            cube[2].transform.position = new Vector3(-6, 0.5f, -4);
            cube[3].transform.position = new Vector3(-5, 0.5f, -7);
            cube[4].transform.position = new Vector3(6, 0.5f, -6);
            cube[5].transform.position = new Vector3(5, 0.5f, 6);
            cube[6].transform.position = new Vector3(-3, 0.5f, 5);
            cube[7].transform.position = new Vector3(-2, 0.5f, 11);
            cube[8].transform.position = new Vector3(-7, 0.5f, 0);
            cube[9].transform.position = new Vector3(3, 0.5f, -4);
            cube[10].transform.position = new Vector3(7, 0.5f, 5);
        }

        public void RoundThree()
        {
            cube = new GameObject[23];
            exit.transform.position = new Vector3(-2, 0, 3);
            exit.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerController.rb.transform.position = new Vector3(0, 1, 0);

            for (var i = 0; i < 23; i++)
            {
                cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube[i].tag = "CollisionBox";
                cube[i].name = "cube_" + i;
                cube[i].GetComponent<MeshRenderer>().material = Material3;
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
        }

        public void RoundFour()
        {
            cube = new GameObject[32];
            exit.transform.position = new Vector3(0, 0, 0);
            playerController.rb.transform.position = new Vector3(0, 1, 0);


            for (var i = 0; i < 32; i++)
            {
                cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube[i].tag = "CollisionBox";
                cube[i].name = "cube_" + i;
                cube[i].GetComponent<MeshRenderer>().material = Material4;
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
            cube[12].transform.position = new Vector3(-7, 0.5f, 10);
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
        }

        public void RoundFive()
        {
            cube = new GameObject[34];
            exit.transform.position = new Vector3(0, 0, 0);
            exit.transform.rotation = Quaternion.Euler(0, 180, 0);
            playerController.rb.transform.position = new Vector3(0, 1, 0);

            for (var i = 0; i < 34; i++)
            {
                cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube[i].tag = "CollisionBox";
                cube[i].name = "cube_" + i;
                cube[i].GetComponent<MeshRenderer>().material = Material5;
            }

            cube[0].transform.position = new Vector3(-2, 0.5f, 0);
            cube[1].transform.position = new Vector3(-1, 0.5f, 6);
            cube[2].transform.position = new Vector3(-4, 0.5f, 5);
            cube[3].transform.position = new Vector3(-3, 0.5f, -5);
            cube[4].transform.position = new Vector3(3, 0.5f, -4);
            cube[5].transform.position = new Vector3(2, 0.5f, -6);
            cube[6].transform.position = new Vector3(8, 0.5f, -5);
            cube[7].transform.position = new Vector3(7, 0.5f, -8);
            cube[8].transform.position = new Vector3(-6, 0.5f, -7);
            cube[9].transform.position = new Vector3(-5, 0.5f, -4);
            cube[10].transform.position = new Vector3(-8, 0.5f, -5);
            cube[11].transform.position = new Vector3(-7, 0.5f, -10);
            cube[12].transform.position = new Vector3(10, 0.5f, -9);
            cube[13].transform.position = new Vector3(9, 0.5f, 4);
            cube[14].transform.position = new Vector3(8, 0.5f, -4);
            cube[15].transform.position = new Vector3(8, 0.5f, 9);
            cube[16].transform.position = new Vector3(6, 0.5f, -1);
            cube[17].transform.position = new Vector3(6, 0.5f, 1);
            cube[18].transform.position = new Vector3(5, 0.5f, -5);
            cube[19].transform.position = new Vector3(5, 0.5f, 5);
            cube[20].transform.position = new Vector3(4, 0.5f, 0);
            cube[21].transform.position = new Vector3(3, 0.5f, 9);
            cube[22].transform.position = new Vector3(2, 0.5f, 2);
            cube[23].transform.position = new Vector3(1, 0.5f, 7);
            cube[24].transform.position = new Vector3(0, 0.5f, -2);
            cube[25].transform.position = new Vector3(0, 0.5f, 2);
            cube[26].transform.position = new Vector3(-3, 0.5f, 8);
            cube[27].transform.position = new Vector3(-5, 0.5f, 7);
            cube[28].transform.position = new Vector3(-6, 0.5f, 1);
            cube[29].transform.position = new Vector3(-9, 0.5f, -3);
            cube[30].transform.position = new Vector3(-9, 0.5f, 6);
            cube[31].transform.position = new Vector3(-11, 0.5f, 3);
            cube[32].transform.position = new Vector3(-7, 0.5f, 11);
            cube[33].transform.position = new Vector3(-10, 0.5f, 5);
        }

        public void RoundSix()
        {
            cube = new GameObject[35];
            spikes.SetActive(true);
            exit.transform.position = new Vector3(0, 0, 0);
            exit.transform.rotation = Quaternion.Euler(0, 180, 0);
            playerController.rb.transform.position = new Vector3(0, 1, 0);

            for (var i = 0; i < 35; i++)
            {
                cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube[i].tag = "CollisionBox";
                cube[i].name = "cube_" + i;
                cube[i].GetComponent<MeshRenderer>().material = Material6;
            }

            cube[0].transform.position = new Vector3(0, 0.5f, 2);
            cube[1].transform.position = new Vector3(3, 0.5f, 1);
            cube[2].transform.position = new Vector3(2, 0.5f, -3);
            cube[3].transform.position = new Vector3(-3, 0.5f, -2);
            cube[4].transform.position = new Vector3(-2, 0.5f, -5);
            cube[5].transform.position = new Vector3(4, 0.5f, -4);
            cube[6].transform.position = new Vector3(3, 0.5f, -8);
            cube[7].transform.position = new Vector3(-4, 0.5f, -7);
            cube[8].transform.position = new Vector3(-3, 0.5f, -12);
            cube[9].transform.position = new Vector3(6, 0.5f, -11);
            cube[10].transform.position = new Vector3(5, 0.5f, 5);
            cube[11].transform.position = new Vector3(8, 0.5f, 4);
            cube[12].transform.position = new Vector3(7, 0.5f, 2);
            cube[13].transform.position = new Vector3(-5, 0.5f, 3);
            cube[14].transform.position = new Vector3(-4, 0.5f, -2);
            cube[15].transform.position = new Vector3(-9, 0.5f, -1);
            cube[16].transform.position = new Vector3(-8, 0.5f, 8);
            cube[17].transform.position = new Vector3(-5, 0.5f, 7);
            cube[18].transform.position = new Vector3(-6, 0.5f, 4);
            cube[19].transform.position = new Vector3(4, 0.5f, 11);

            cube[20].transform.position = new Vector3(12, 0.5f, -11);
            cube[21].transform.position = new Vector3(10, 0.5f, 0);
            cube[22].transform.position = new Vector3(9, 0.5f, -10);
            cube[23].transform.position = new Vector3(-10, 0.5f, -11);
            cube[24].transform.position = new Vector3(-11, 0.5f, 4);
            cube[25].transform.position = new Vector3(-10, 0.5f, -6);
            cube[26].transform.position = new Vector3(-12, 0.5f, 2);
            cube[27].transform.position = new Vector3(0, 0.5f, -13);
            cube[28].transform.position = new Vector3(12, 0.5f, -6);
            cube[29].transform.position = new Vector3(-13, 0.5f, 7);
            cube[30].transform.position = new Vector3(8, 0.5f, 10);
            cube[31].transform.position = new Vector3(7, 0.5f, 12);
            cube[32].transform.position = new Vector3(-4, 0.5f, 14);
            cube[33].transform.position = new Vector3(10, 0.5f, 6);
            cube[34].transform.position = new Vector3(6, 0.5f, 15);
        }

        public void RoundSeven()
        {
            cube = new GameObject[35];
            spikes.SetActive(false);
            exit.transform.position = new Vector3(0, 0, 0);
            exit.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerController.rb.transform.position = new Vector3(0, 1, 0);

            for (var i = 0; i < 35; i++)
            {
                cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube[i].tag = "CollisionBox";
                cube[i].name = "cube_" + i;
                cube[i].GetComponent<MeshRenderer>().material = Material7;
            }

            cube[0].transform.position = new Vector3(2, 0.5f, 0);
            cube[1].transform.position = new Vector3(1, 0.5f, 3);
            cube[2].transform.position = new Vector3(-3, 0.5f, 2);
            cube[3].transform.position = new Vector3(-2, 0.5f, -3);
            cube[4].transform.position = new Vector3(-5, 0.5f, -2);
            cube[5].transform.position = new Vector3(-4, 0.5f, 4);
            cube[6].transform.position = new Vector3(-8, 0.5f, 3);
            cube[7].transform.position = new Vector3(-7, 0.5f, -2);
            cube[8].transform.position = new Vector3(-12, 0.5f, -3);
            cube[9].transform.position = new Vector3(-11, 0.5f, 6);
            cube[10].transform.position = new Vector3(5, 0.5f, 5);
            cube[11].transform.position = new Vector3(4, 0.5f, 8);
            cube[12].transform.position = new Vector3(2, 0.5f, 7);
            cube[13].transform.position = new Vector3(3, 0.5f, -5);
            cube[14].transform.position = new Vector3(-2, 0.5f, -4);
            cube[15].transform.position = new Vector3(-1, 0.5f, -9);
            cube[16].transform.position = new Vector3(8, 0.5f, -8);
            cube[17].transform.position = new Vector3(7, 0.5f, -5);
            cube[18].transform.position = new Vector3(4, 0.5f, -6);
            cube[19].transform.position = new Vector3(11, 0.5f, 4);

            cube[20].transform.position = new Vector3(-11, 0.5f, 12);
            cube[21].transform.position = new Vector3(0, 0.5f, 10);
            cube[22].transform.position = new Vector3(-10, 0.5f, 9);
            cube[23].transform.position = new Vector3(-11, 0.5f, -10);
            cube[24].transform.position = new Vector3(4, 0.5f, -11);
            cube[25].transform.position = new Vector3(-6, 0.5f, -10);
            cube[26].transform.position = new Vector3(2, 0.5f, -12);
            cube[27].transform.position = new Vector3(-13, 0.5f, 0);
            cube[28].transform.position = new Vector3(-6, 0.5f, 12);
            cube[29].transform.position = new Vector3(7, 0.5f, -13);
            cube[30].transform.position = new Vector3(10, 0.5f, 8);
            cube[31].transform.position = new Vector3(12, 0.5f, 7);
            cube[32].transform.position = new Vector3(14, 0.5f, -4);
            cube[33].transform.position = new Vector3(6, 0.5f, 10);
            cube[34].transform.position = new Vector3(15, 0.5f, 6);
        }
    }
}
