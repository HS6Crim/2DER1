using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    GameObject player; // reference to the player so we can track it's position
    Renderer rend; // Reference to the renderer so we can modify it's texture

    float playerStartPos; // Float used to track the starting position of the player
    public float speed = 0.5f; // how fast to scroll (change for each layer)

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("char001"); // find the player
        rend = GetComponent<Renderer>(); // find the renderer
        playerStartPos = player.transform.position.x; // Save our start pos
    }

    // Update is called once per frame
    void Update()
    {
        float offset = (player.transform.position.x - playerStartPos) * speed;
        // this line finds out how much to offset the texture by
        // we do this bu subtracting our x position from our current position
        // we then multioply the offset by the speed, so that we can have different layers
        // at different speeds.

        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
        // This line sets our texture 'offset' we use the SetTextureOffset
        // method to do this, which takes 2 parameters.
        // the first parameter a string referring to the texture we want to modify.
        // the second is a Vector2, with the first(x) variable shifting the texture
        // left and right, and the second (y) variable shifting the texture up and down.
    }
}