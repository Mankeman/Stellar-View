using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Constellation : MonoBehaviour
{
    //Details about the constellations
    public string constellationName;
    public Sprite constellationImage;
    [TextAreaAttribute(10, 20)]
    public string constellationDescription;
}
