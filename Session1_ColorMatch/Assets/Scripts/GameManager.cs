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

           
            //gridSpace.GetChild(i).gameObject.
            //    GetComponent<Button>().onClick.
            //    AddListener(()=>ColorButtonClicked(i));
        }
    }

    public void ColorButtonClicked(int colorIndex)
    {
        Debug.Log("Index: "+ colorIndex);
        gridSpace.GetChild(colorIndex).
            GetComponent<Image>().color = Color.clear;
    }




}

[System.Serializable]
public class ColorData
{
    public string colorName;
    public Color color;
}
