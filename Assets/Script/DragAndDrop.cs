using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Imageコンポーネント
[RequireComponent(typeof(Image))]

// ドラッグとドロップに関するインターフェースを実装
public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    // ドラッグ前の位置
    static public Vector2 prevPos;
    static public bool Overlap;
    static public bool PuzCheck = false;
    static public int px;
    static public int py;

    void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置を記憶
        prevPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ドラッグ中は位置を更新する
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置に戻す
        transform.position = prevPos;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (var hit in raycastResults)
        {
            // もし DroppableField の上なら、その位置に固定する
            if (hit.gameObject.CompareTag("DroppableField"))
            {
                //おいていい場所か確認する処理

                //Puzzlefieldが5以外なら置かない処理                

                transform.position = hit.gameObject.transform.position;               
                this.enabled = false;
                MakePuzzle.LHS_Bool = false;
                Vector2 NowPos = hit.gameObject.transform.localPosition;

                var posx = NowPos.x + 250;
                px = Mathf.FloorToInt(posx / 100);

                var posy = NowPos.y + 250;
                py = 4 - Mathf.FloorToInt(posy / 100);

                switch (MakePuzzle.Checker)
                {
                    case 0:
                        FieldControl.PuzzleField[px, py] = MakePuzzle.Color1;
                        FieldControl.PuzzleField[px + 1, py] = MakePuzzle.Color2;
                        FieldControl.objectsField[px, py] = MakePuzzle.prefabs[0];
                        FieldControl.objectsField[px + 1, py] = MakePuzzle.prefabs[1];
                        break;

                    case 1:
                        FieldControl.PuzzleField[px, py] = MakePuzzle.Color1;
                        FieldControl.PuzzleField[px, py + 1] = MakePuzzle.Color2;
                        FieldControl.objectsField[px, py] = MakePuzzle.prefabs[0];
                        FieldControl.objectsField[px, py + 1] = MakePuzzle.prefabs[1];
                        break;

                    case 2:
                        FieldControl.PuzzleField[px, py] = MakePuzzle.Color1;
                        FieldControl.PuzzleField[px + 1, py] = MakePuzzle.Color2;
                        FieldControl.PuzzleField[px, py + 1] = MakePuzzle.Color3;
                        FieldControl.objectsField[px, py] = MakePuzzle.prefabs[0];
                        FieldControl.objectsField[px + 1, py] = MakePuzzle.prefabs[1];
                        FieldControl.objectsField[px, py + 1] = MakePuzzle.prefabs[2];
                        break;

                    case 3:
                        FieldControl.PuzzleField[px, py] = MakePuzzle.Color1;
                        FieldControl.PuzzleField[px + 1, py] = MakePuzzle.Color2;
                        FieldControl.PuzzleField[px + 1, py - 1] = MakePuzzle.Color3;
                        FieldControl.objectsField[px, py] = MakePuzzle.prefabs[0];
                        FieldControl.objectsField[px + 1, py] = MakePuzzle.prefabs[1];
                        FieldControl.objectsField[px + 1, py - 1] = MakePuzzle.prefabs[2];
                        break;

                    case 4:

                        break;

                    case 5:

                        break;

                    case 6:

                        break;

                }
            }
        }
    }
}