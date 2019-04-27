using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakePuzzle : MonoBehaviour {
    public GameObject canvas;
    public GameObject Puzzle;
    public GameObject oya;
    private GameObject prefab;
    static public GameObject Parent;
    public GameObject LHS;
    private Color[] colorTable = {
        new Color(1, 0, 0, 1),
        new Color(0, 1, 0, 1),
        new Color(0, 0, 1, 1),
        new Color(1, 1, 1, 1),
        new Color(0, 0, 0, 1),
    };
    public static bool LHS_Bool = false;
    private int randColor;
    private int[] zahyou = new int[] { 0, 100, 100 };
    static public int Color1 = 0;
    static public int Color2 = 0;
    static public int Color3 = 0;
    static public int Color4 = 0;
    static public GameObject[] prefabs = new GameObject[4];
    private int Value = 0;
    static public int Checker = 0;
    static public int ColorInfo;
    public Image image;
    [SerializeField]
    private Sprite sprite;    

    void Start () {

    }
	
	void Update () {
        Stage1();
	}
    public void Stage1()
    {
        Value = Random.Range(0, 11);
        if (LHS_Bool == false)
        {
            if (Value >= 0 && Value <= 6)
            {
                int rnd = Random.Range(0, 11);
                if (rnd >= 0 && rnd <= 5)
                {
                    Checker = 0;
                    Parent = Instantiate(oya);
                    Parent.transform.SetParent(canvas.transform, false);
                    Parent.transform.position = LHS.transform.position;
                    for (int i = 0; i <= 1; i++)
                    {
                        randColor = Random.Range(0, 5);
                        prefab = Instantiate(Puzzle);
                        prefab.transform.SetParent(canvas.transform, false);
                        prefab.GetComponent<Image>().color = colorTable[randColor];
                        prefab.transform.position = new Vector2(LHS.transform.position.x + zahyou[i], LHS.transform.position.y);
                        prefab.transform.SetParent(Parent.transform);
                        if (randColor == 4)
                        {
                            prefab.GetComponent<Image>().sprite = sprite;
                            prefab.GetComponent<Image>().color = colorTable[3];
                        }
                        if (i == 0)
                        {
                            Color1 = randColor;
                        }
                        else if (i == 1)
                        {
                            Color2 = randColor;
                        }
                        prefabs[i] = prefab;
                    }
                    LHS_Bool = true;
                }
                else if (rnd >= 6 && rnd <= 11)
                {
                    Checker = 1;
                    Parent = Instantiate(oya);
                    Parent.transform.SetParent(canvas.transform, false);
                    Parent.transform.position = LHS.transform.position;
                    for (int i = 0; i <= 1; i++)
                    {
                        randColor = Random.Range(0, 5);
                        prefab = Instantiate(Puzzle);
                        prefab.transform.SetParent(canvas.transform, false);
                        prefab.GetComponent<Image>().color = colorTable[randColor];
                        prefab.transform.position = new Vector2(LHS.transform.position.x, LHS.transform.position.y - zahyou[i]);
                        prefab.transform.SetParent(Parent.transform);
                        if (randColor == 4)
                        {
                            prefab.GetComponent<Image>().sprite = sprite;
                            prefab.GetComponent<Image>().color = colorTable[3];
                        }
                        if (i == 0)
                        {
                            Color1 = randColor;
                        }
                        else if (i == 1)
                        {
                            Color2 = randColor;
                        }
                        prefabs[i] = prefab;
                    }
                    LHS_Bool = true;
                }
            }
            else if (Value >= 7 && Value <= 9)
            {
                int rnd = Random.Range(0, 11);
                if (rnd >= 0 && rnd <= 5)
                {
                    Checker = 2;
                    Parent = Instantiate(oya);
                    Parent.transform.SetParent(canvas.transform, false);
                    Parent.transform.position = LHS.transform.position;
                    for (int i = 0; i <= 2; i++)
                    {
                        randColor = Random.Range(0, 5);
                        if (i == 2)
                        {
                            prefab = Instantiate(Puzzle);
                            prefab.transform.SetParent(canvas.transform, false);
                            prefab.GetComponent<Image>().color = colorTable[randColor];
                            prefab.transform.position = new Vector2(LHS.transform.position.x, LHS.transform.position.y - zahyou[i]);
                            prefab.transform.SetParent(Parent.transform);
                            prefabs[i] = prefab;
                            LHS_Bool = true;
                            if (randColor == 4)
                            {
                                prefab.GetComponent<Image>().sprite = sprite;
                                prefab.GetComponent<Image>().color = colorTable[3];
                            }
                            return;
                        }
                        prefab = Instantiate(Puzzle);
                        prefab.transform.SetParent(canvas.transform, false);
                        prefab.GetComponent<Image>().color = colorTable[randColor];
                        prefab.transform.position = new Vector2(LHS.transform.position.x + zahyou[i], LHS.transform.position.y);
                        prefab.transform.SetParent(Parent.transform);

                        if (randColor == 4)
                        {
                            prefab.GetComponent<Image>().sprite = sprite;
                            prefab.GetComponent<Image>().color = colorTable[3];
                        }
                        if (i == 0)
                        {
                            Color1 = randColor;
                        }
                        else if (i == 1)
                        {
                            Color2 = randColor;
                        }
                        else if (i == 2)
                        {
                            Color3 = randColor;
                        }                        

                        prefabs[i] = prefab;

                    }
                }
                else if (rnd >= 6 && rnd <= 11)
                {
                    Checker = 3;
                    Parent = Instantiate(oya);
                    Parent.transform.SetParent(canvas.transform, false);
                    Parent.transform.position = LHS.transform.position;
                    for (int i = 0; i <= 2; i++)
                    {
                        randColor = Random.Range(0, 5);
                        if (i == 2)
                        {
                            prefab = Instantiate(Puzzle);
                            prefab.transform.SetParent(canvas.transform, false);
                            prefab.GetComponent<Image>().color = colorTable[randColor];
                            prefab.transform.position = new Vector2(LHS.transform.position.x + zahyou[i], LHS.transform.position.y + zahyou[i]);
                            prefab.transform.SetParent(Parent.transform);
                            prefabs[i] = prefab;
                            LHS_Bool = true;
                            if (randColor == 4)
                            {
                                prefab.GetComponent<Image>().sprite = sprite;
                                prefab.GetComponent<Image>().color = colorTable[3];
                            }
                            return;
                        }
                        prefab = Instantiate(Puzzle);
                        prefab.transform.SetParent(canvas.transform, false);
                        prefab.GetComponent<Image>().color = colorTable[randColor];
                        prefab.transform.position = new Vector2(LHS.transform.position.x + zahyou[i], LHS.transform.position.y);
                        prefab.transform.SetParent(Parent.transform);

                        if (randColor == 4)
                        {
                            prefab.GetComponent<Image>().sprite = sprite;
                            prefab.GetComponent<Image>().color = colorTable[3];
                        }
                        if (i == 0)
                        {
                            Color1 = randColor;
                        }
                        else if (i == 1)
                        {
                            Color2 = randColor;
                        }
                        else if (i == 2)
                        {
                            Color3 = randColor;
                        }                       

                        prefabs[i] = prefab;
                    }
                }
            }

            //else if (Value == 10)
            //{
            //    Debug.Log("c");
            //}      
        }
    }
}
