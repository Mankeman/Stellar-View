using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Constellation Details
    [Header("ConstellationDetails")]
    public Text constellationName;
    public Image constellationImage;
    public Text constellationDescription;

    public GameObject backpack;
    // Start is called before the first frame update
    void Start()
    {
        backpack = GameObject.FindGameObjectWithTag("Backpack");
        backpack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            backpack.SetActive(true);

        else if (Input.GetKeyUp(KeyCode.I))
            backpack.SetActive(false);

    }
    public void Constellation(string name, Sprite image, string description)
    {
        //Set the constellation information
        constellationName.text = name;
        constellationImage.sprite = image;
        constellationDescription.text = description;
    }
}
