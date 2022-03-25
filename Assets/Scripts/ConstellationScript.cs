using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationScript : MonoBehaviour
{
    private CameraController playerCamScript;
    private Camera playerCam;
    private GameController gameController;
    public GameObject backpack;
    public float rayDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
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
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        Debug.DrawRay(origin, direction, Color.red);
        Ray ray = new Ray(origin, direction);

        bool starHit = Physics.Raycast(ray, out RaycastHit raycastHit);

        if (playerCamScript.isZoomed && starHit && raycastHit.collider.gameObject.name == "Constellation")
        {
            GameObject childConnections = raycastHit.collider.transform.GetChild(0).gameObject;
            Constellation constellation = raycastHit.collider.transform.GetChild(1).GetComponent<Constellation>();
            childConnections.SetActive(true);
            gameController.Constellation(constellation.constellationName, constellation.constellationImage, constellation.constellationDescription);
            backpack.SetActive(true);
        }
        else if (!playerCamScript.isZoomed && starHit && raycastHit.collider.gameObject.name == "Constellation")
        {
            GameObject childConnections = raycastHit.collider.transform.GetChild(0).gameObject;
            childConnections.SetActive(false);
            backpack.SetActive(false);
        }
    }
}
