using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Play_Intro : MonoBehaviour
{
    public GameObject player;
    public List<Transform> playerWayPoints;

    private void Start()
    {
        Play();
    }

    public void Play()
    {
        StartCoroutine(C_Player());
    }

    private IEnumerator C_Player()
    {
        NavMeshAgent agent = player.GetComponent<NavMeshAgent>();
        Animator animator = player.GetComponent<Animator>();
        Transform transform = player.transform;

        for (int i = 0; i < playerWayPoints.Count; i++)
        {
            while (Vector3.Distance(transform.position, playerWayPoints[i].position) > 0.2f)
            {
                transform.LookAt(playerWayPoints[i]);
                animator.SetFloat("vertical", 0.5f);
                yield return null;
            }
        }
        animator.SetFloat("vertical", 0.0f);
    }
}
