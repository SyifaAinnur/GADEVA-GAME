using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private Transform clickAnim;
    [SerializeField] private GameObject profile;
    [SerializeField] private float speed;

    private float timeProfileToAppears;
    private Vector3 moveTo;
    private Camera cam;
    private float camZPosition;


    private void Start()
    {
        cam = Camera.main;
        camZPosition = cam.transform.position.z;
        timeProfileToAppears = 0;
    }

    private void Update()
    {
        if (timeProfileToAppears < 0)
        {
            profile.SetActive(true);
        } 
        else timeProfileToAppears--;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 startPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            startPosition.z = camZPosition;

            //Animation Click
            clickAnim.gameObject.SetActive(false);
            clickAnim.gameObject.SetActive(true);

            Vector3 clickPos = startPosition;
            clickPos.z = clickAnim.position.z;
            clickAnim.position = clickPos;

            RaycastHit2D[] hit = Physics2D.RaycastAll(startPosition, cam.transform.forward, 20, -1);
            foreach (RaycastHit2D item in hit)
            {
                if (item)
                {
                    if (item.collider.name.Equals("Base"))
                    {
                        profile.SetActive(false);
                        timeProfileToAppears = 300;

                        moveTo = item.point;
                        moveTo.z = transform.position.z;

                        hit = null;
                        break;
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (transform.position != moveTo) 
        {
            transform.position = Vector3.Lerp(transform.position, moveTo, speed);

            Vector3 cameraMovement = transform.position;
            cameraMovement.z = camZPosition;
            cam.transform.position = cameraMovement;
        }
    }
}
