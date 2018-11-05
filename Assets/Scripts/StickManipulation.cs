using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class StickManipulation : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] Transform cameratransform;
    [SerializeField] float sensibility = 1;
    [SerializeField] float defaultposY = 32;
    float positionY;
    public bool isMoving;

    /*
    Left Controller Trackpad (2)		Left Controller Trackpad	Horizontal Movement		1	–1.0 to 1.0
    Left Controller Trackpad (2)		Left Controller Trackpad	Vertical Movement		2	–1.0 to 1.0
    Right Controller Trackpad (2)		Right Controller Trackpad	Horizontal Movement		4	–1.0 to 1.0
    Right Controller Trackpad (2)		Right Controller Trackpad	Vertical Movement		5	–1.0 to 1.0
    */

    [SerializeField] SteamVR_Input_Sources thisHand;
    private void Start()
    {
        positionY = transform.position.y;

    }
    private void Update()
    {
        if (isMoving)
        {
            Move();
        }

    }

    public void Move()
    {
        Vector2 moveaxis = SteamVR_Input.__actions_default_in_TrackPad.GetAxis(thisHand);

        player.position += (cameratransform.right * moveaxis.x + cameratransform.forward * moveaxis.y) * Time.deltaTime * sensibility;
        player.position = new Vector3(player.position.x, defaultposY, player.position.z);
    }


}