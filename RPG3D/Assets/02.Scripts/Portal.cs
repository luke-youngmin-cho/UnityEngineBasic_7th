using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Map from;
    public Map to;

    // 
    public void Transport(Transform player)
    {
        // 일반던전포탈
        player.position 
            =  World.instance.portals.Find(x => x.from == this.to && x.to == this.from).transform.position;

        // 히든던전포탈
        player.position
            = World.instance.portals.Find(x => x.from == this.to ).transform.position;
    }

}
