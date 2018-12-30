using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class Rounds : PlayerController
{
    //List<Material> arrayOfMaterials = new List<Material>();

    


    public GameObject exit;
    //public Material[] mats;
    //Material mcrate;
    //Material mcrate2;
    //Material m_Material;
    //Material newMat = Resources.FindObjectsOfTypeAll("crate", typeof(Material)) as Material;
    //Resources.FindObjectsOfTypeAll(typeof(Material))
   
    public void StartRound()
    {
        //mcrate = GetComponent<Material>();

        //mcrate2 = GetComponent<Material>();

        //m_Material = GetComponent<Material>();

        //mcrate = Resources.Load<Material>("crate");

        //m_Material = (Material)Resources.Load("Materials", m_Material.GetType());




        //mcrate= Resources.Load("/Materials/crate", typeof(Material)) as Material;



        //m_Material = (Material)Resources.Load("Material/Fence.mat", m_Material.GetType());
        //for (int i = 0; i < arrayOfMaterials.Count; i++)
        // arrayOfMaterials = (Material)Resources.LoadAll("Materials", mcrate.GetType());
        //arrayOfMaterials = (Material)Resources.LoadAll("qweqe", mcrate.GetType());
        //GUILayout.Label("Total duplicate materials");
        //for (int i = 0; i < arrayOfMaterials.Count; i++)
        //{
        //    //mcrate = Resources.Load("crate", typeof(Material)) as Material;

        //    //EditorGUILayout.LabelField(i.ToString(), arrayOfMaterials[i].name);
        //}

        //foreach (Material c in Resources.FindObjectsOfTypeAll(typeof(Material)))
        //{
        //    arrayOfMaterials.Add(c);
        //}

        //mcrate = GetComponent<Renderer>().material;
        ////m_Material = GetComponent<Renderer>().material;
        ////m_Material = GetComponent<Renderer>().material;
        //m_Material = GetComponent<Material>();

        for (int i = 0; i < cube.Length; i++)
        {
            Destroy(cube[i]);
        }

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
                //default:
                //    Background.gameObject.SetActive(true);
                //    break;
        }
    }

    public void RoundOne()
    {
        //Material[] mats = Resources.LoadAll("Materials", typeof(Material)).Cast<Material>().ToArray();
        for (int i = 0; i < 5; i++)
        {
            cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube[i].tag = "CollisionBox";
            cube[i].name = "cube_" + i;
            cube[i].GetComponent<Renderer>().material.color = Color.blue;
        }

        cube[0].transform.position = new Vector3(4, 0.5f, 0);
        cube[1].transform.position = new Vector3(-6, 0.5f, 0);
        cube[2].transform.position = new Vector3(1, 0.5f, -9);
        cube[3].transform.position = new Vector3(0, 0.5f, -13);
        cube[4].transform.position = new Vector3(3, 0.5f, -14);
        rb.transform.position = new Vector3(0, 1, 0);
        touch = true;
    }

    public void RoundTwo()
    {
        exit.transform.position = new Vector3(0, 0, 3);

        for (int i = 0; i < 23; i++)
        {
            cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube[i].tag = "CollisionBox";
            cube[i].name = "cube_" + i;
            cube[i].GetComponent<Renderer>().material.color = Color.red;
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

    public void RoundThree()
    {
        exit.transform.position = new Vector3(0, 0, 0);
        for (int i = 0; i < 32; i++)
        {
            cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube[i].tag = "CollisionBox";
            cube[i].name = "cube_" + i;
            cube[i].GetComponent<Renderer>().material.color = Color.green;
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

    public void RoundFour()
    {
        exit.transform.position = new Vector3(0, 0, 0);
        for (int i = 0; i < 32; i++)
        {
            cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube[i].tag = "CollisionBox";
            cube[i].name = "cube_" + i;
            cube[i].GetComponent<Renderer>().material.color = Color.cyan;
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
}
