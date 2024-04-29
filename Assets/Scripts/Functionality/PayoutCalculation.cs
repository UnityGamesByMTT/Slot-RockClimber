using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class PayoutCalculation : MonoBehaviour
{
    [SerializeField]
    private int x_Distance;
    [SerializeField]
    private int y_Distance;

    [SerializeField]
    private Transform LineContainer;
    [SerializeField]
    private GameObject Line_Prefab;

    [SerializeField]
    private Vector2 InitialLinePosition = new Vector2(-315, 100);

    [SerializeField] internal List<int> LineList;
    [SerializeField] private List<GameObject> LineObjetcs;
    [SerializeField] internal List<int> DontDestroyLines = new List<int>();

    internal int CurrentLines;
    internal int LineIndex;

    GameObject TempObj = null;

    [SerializeField] private GameObject[] activeLineButtons;
    [SerializeField] private GameObject[] inActiveLineButtons;

    private void Start()
    {
        CurrentLines = LineList[LineList.Count - 1];
        LineIndex = LineList.Count - 1;
        inActiveLineButtons[LineIndex].SetActive(false);
        activeLineButtons[LineIndex].SetActive(true);

    }

    //generate lines at runtime accordingly
    internal void GeneratePayoutLinesBackend(int index = -1, bool DestroyFirst = true)
    {

        if (DestroyFirst)
            ResetStaticLine();
        if (index >= 0)
        {
            LineObjetcs[index - 1].SetActive(true);
            print(LineObjetcs[index - 1].name);
            return;
        }
        DontDestroyLines.Clear();
        for (int i = 0; i < LineList[LineIndex]; i++)
        {
            LineObjetcs[i].SetActive(true);


        }


    }

    internal void ToggleLineOff() {

        CurrentLines = LineList[LineIndex];
        for (int j = 0; j < LineList.Count; j++)
        {
            activeLineButtons[j].SetActive(false);
            inActiveLineButtons[j].SetActive(true);
        }

        int k = LineList.IndexOf(CurrentLines);
        StartCoroutine(Set_button_state(k, 0.1f));
    }

    IEnumerator Set_button_state(int  i, float time)
    {
        inActiveLineButtons[i].SetActive(false);
        yield return new WaitForSeconds(time);
        activeLineButtons[i].SetActive(true);

    }
    //delete the line generated by button hover
    internal void ResetStaticLine()
    {
        for (int i = 0; i < LineObjetcs.Count; i++)
        {
            if (DontDestroyLines.IndexOf(i) >= 0)
                continue;
            else
                LineObjetcs[i].SetActive(false);
        }
    }

    //delete all lines
    internal void ResetLines()
    {
        //foreach (Transform child in LineContainer)
        //{
        //    Destroy(child.gameObject);
        //}
    }



}
