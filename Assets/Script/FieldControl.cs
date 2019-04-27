using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldControl : MonoBehaviour {
    
    public Canvas canvas;
    static public int[,] PuzzleField = new int[5,5];
    static public GameObject[,] objectsField = new GameObject[5, 5];    

    void Start () {
        for(int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                var panel = Resources.Load<GameObject>("Field");
                var p = Instantiate<GameObject>(panel);
                p.transform.SetParent(canvas.transform, false);
                p.transform.localPosition = new Vector2(100 * x - 200, 200 - 100 * y);
                PuzzleField[x,y] = 5;
            }
        }
    }
	void Update () {      
	}
}
