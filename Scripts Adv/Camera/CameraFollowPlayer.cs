using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureGame
{
    public class CameraFollowPlayer : MonoBehaviour
    {
        public Transform playerTransform = null;

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(playerTransform.position.x, transform.position.y, -10);
        }
    }
}
