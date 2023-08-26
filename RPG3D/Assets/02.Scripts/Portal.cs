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
        // �Ϲݴ�����Ż
        player.position 
            =  World.instance.portals.Find(x => x.from == this.to && x.to == this.from).transform.position;

        // ���������Ż
        player.position
            = World.instance.portals.Find(x => x.from == this.to ).transform.position;
    }

}
