using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        PLAYING,
        PAUSED,
        LEVELCOMPLETE,
        RESTART,
        NONE
    }

    [SerializeField] ColorData[] colorList;
    public GameState currGameState = GameState.NONE;

    [SerializeField] Text colorNameText;
    [SerializeField] Image colorIndetifierImage;
    [SerializeField] Transform gridSpace;

    ColorData currColorData;
    private void Awake()
    {
        currColorData = colorList[Random.Range(0, colorList.Length - 1)];
        colorNameText.text = "Color: " + currColorData.colorName;
        colorIndetifierImage.color = currColorData.color;
    }
    private void Start()
    {
        for (int i = 0; i < gridSpace.childCount; i++)
        {
            gridSpace.GetChild(i).gameObject.
                GetComponent<Image>().color = 
                colorList[Random.Range(0, colorList.Length - 1)].color;

            int value = i;
            gridSpace.GetChild(value).gameObject.
                GetComponent<Button>().onClick.
                AddListener(() => ColorButtonClicked(value));
        }

        currGameState = GameState.PLAYING;
    }

    public void ColorButtonClicked(int colorIndex)
    {
        if (currGameState == GameState.PLAYING)
        {
            CheckForLevelFail(colorIndex);
            
            gridSpace.GetChild(colorIndex).
                GetComponent<Image>().color = Color.clear;

            CheckForLevelWin(colorIndex);
        }

    }

    void CheckForLevelFail(int clickedIndex)
    {
        if (gridSpace.GetChild(clickedIndex).GetComponent<Image>().color != 
            currColorData.color)
        {
            Debug.Log("LEVEL_FAIL");
           // Show Level Fail Screen
        }
    }

    void CheckForLevelWin(int clickedIndex)
    {
        for (int i = 0; i < gridSpace.childCount; i++)
        {
            if (gridSpace.GetChild(i).GetComponent<Image>().color == currColorData.color)
            {
                Debug.Log(currColorData.colorName + " still exists in the grid!!");
                return;
            }
        }
        Debug.Log("LEVEL WIN");
    }



}

[System.Serializable]
public class ColorData
{
    public string colorName;
    public Color color;
}
