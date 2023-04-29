using UnityEngine;

public class GoalLine : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask; // 00000000 00000000 00000010 00000000
    [SerializeField] private RaceManager _raceManager;

    private void OnTriggerEnter(Collider other)
    {
        if ((1<<other.gameObject.layer & _targetMask) > 0)
        {
            _raceManager.RegisterFinishedHorse(other.GetComponent<Horse>());
        }
    }
}
