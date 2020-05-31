using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    int hairCount, maxHairCount;
    int topCount, maxTopCount;
    int pantsCount, maxPantsCount;

    [SerializeField] private GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("hairCount")) { hairCount = PlayerPrefs.GetInt("hairCount"); }
        else
        {
            PlayerPrefs.SetInt("hairCount", 0);
            hairCount = PlayerPrefs.GetInt("hairCount");
        }
        if(PlayerPrefs.HasKey("topCount")) { topCount = PlayerPrefs.GetInt("topCount"); }
        else
        {
            PlayerPrefs.SetInt("topCount", 0);
            topCount = PlayerPrefs.GetInt("topCount");
        }
        if(PlayerPrefs.HasKey("pantsCount")) { pantsCount = PlayerPrefs.GetInt("pantsCount"); }
        else
        {
            PlayerPrefs.SetInt("pantsCount", 0);
            pantsCount = PlayerPrefs.GetInt("pantsCount");
        }

        model = GameObject.Find("girl_T_pose_1");

        maxHairCount = model.transform.GetChild(2).childCount;
        maxTopCount = model.transform.GetChild(4).childCount;
        maxPantsCount = model.transform.GetChild(0).childCount;

        model.transform.GetChild(2).GetChild(hairCount).gameObject.SetActive(true);
        model.transform.GetChild(4).GetChild(topCount).gameObject.SetActive(true);
        model.transform.GetChild(0).GetChild(pantsCount).gameObject.SetActive(true);
    }

    public void OnHairLeftButton()
    {
        model.transform.GetChild(2).GetChild(hairCount).gameObject.SetActive(false);
        hairCount--;
        if(hairCount < 0) { hairCount = maxHairCount - 1; }
        model.transform.GetChild(2).GetChild(hairCount).gameObject.SetActive(true);
    }

    public void OnHairRightButton()
    {
        model.transform.GetChild(2).GetChild(hairCount).gameObject.SetActive(false);
        hairCount++;
        if(hairCount == maxHairCount) { hairCount = 0; }
        model.transform.GetChild(2).GetChild(hairCount).gameObject.SetActive(true);
    }

    public void OnTopLeftButton()
    {
        model.transform.GetChild(4).GetChild(topCount).gameObject.SetActive(false);
        topCount--;
        if(topCount < 0) { topCount = maxTopCount - 1; }
        model.transform.GetChild(4).GetChild(topCount).gameObject.SetActive(true);
    }

    public void OnTopRightButton()
    {
        model.transform.GetChild(4).GetChild(topCount).gameObject.SetActive(false);
        topCount++;
        if(topCount == maxTopCount) { topCount = 0; }
        model.transform.GetChild(4).GetChild(topCount).gameObject.SetActive(true);
    }

    public void OnPantsLeftButton()
    {
        model.transform.GetChild(0).GetChild(pantsCount).gameObject.SetActive(false);
        pantsCount--;
        if (pantsCount < 0) { pantsCount = maxPantsCount - 1; }
        model.transform.GetChild(0).GetChild(pantsCount).gameObject.SetActive(true);
    }

    public void OnPantsRightButton()
    {
        model.transform.GetChild(0).GetChild(pantsCount).gameObject.SetActive(false);
        pantsCount++;
        if(pantsCount == maxPantsCount) { pantsCount = 0; }
        model.transform.GetChild(0).GetChild(pantsCount).gameObject.SetActive(true);
    }

    public void OnSaveButton()
    {
        PlayerPrefs.SetInt("hairCount", hairCount);
        PlayerPrefs.SetInt("topCount", topCount);
        PlayerPrefs.SetInt("pantsCount", pantsCount);
    }

    public void OnLoadButton()
    {
        model.transform.GetChild(2).GetChild(hairCount).gameObject.SetActive(false);
        hairCount = PlayerPrefs.GetInt("hairCount");
        model.transform.GetChild(4).GetChild(topCount).gameObject.SetActive(false);
        topCount = PlayerPrefs.GetInt("topCount");
        model.transform.GetChild(0).GetChild(pantsCount).gameObject.SetActive(false);
        pantsCount = PlayerPrefs.GetInt("pantsCount");
        model.transform.GetChild(2).GetChild(hairCount).gameObject.SetActive(true);
        model.transform.GetChild(4).GetChild(topCount).gameObject.SetActive(true);
        model.transform.GetChild(0).GetChild(pantsCount).gameObject.SetActive(true);
    }
}
