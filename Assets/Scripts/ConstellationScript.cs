using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationScript : MonoBehaviour
{
    //Find scripts and components in game.
    private CameraController playerCamScript;
    private Camera playerCam;
    private GameController gameController;
    public GameObject backpack;
    
    // Start is called before the first frame update
    void Start()
    {
        //Start of the game, find specific components.
        playerCamScript = FindObjectOfType<Camera>().GetComponent<CameraController>();
        playerCam = FindObjectOfType<Camera>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        FoundConstellation();
    }
    void FoundConstellation()
    {
        //Where is the beam going to exit from?
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        //Create the ray
        Ray ray = new Ray(origin, direction);

        //Bool to confirm that the ray hit something
        bool starHit = Physics.Raycast(ray, out RaycastHit raycastHit);

        //if the player is zoomed, we hit a star and it's a part of a constellation
        if (playerCamScript.isZoomed && starHit && raycastHit.collider.gameObject.tag == "Star")
        {
            //Make the lines active and show them to the player.
            GameObject childConnections = raycastHit.collider.transform.GetChild(0).gameObject;
            childConnections.SetActive(true);

            //Send constellation info to the game controller and display it to the player.
            Constellation constellation = raycastHit.collider.transform.GetChild(1).GetComponent<Constellation>();
            gameController.Constellation(constellation.constellationName, constellation.constellationImage, constellation.constellationDescription);
            backpack.SetActive(true);
        }
        //if player isn't zoomed but a star was hit and it's part of a constellation
        else if (!playerCamScript.isZoomed && starHit && raycastHit.collider.gameObject.tag == "Star")
        {
            //Turn off the lines
            GameObject childConnections = raycastHit.collider.transform.GetChild(0).gameObject;
            childConnections.SetActive(false);

            //Don't display it to the player.
            backpack.SetActive(false);
        }
    }
}
