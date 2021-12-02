using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundArea : MonoBehaviour {
    public float speedarea;
    // Update is called once per frame
    void Update() {
        if (Player.groundmaju)
        {
            transform.Translate(Vector2.left * speedarea * Time.deltaTime);
        } else
            return;
    }
}
