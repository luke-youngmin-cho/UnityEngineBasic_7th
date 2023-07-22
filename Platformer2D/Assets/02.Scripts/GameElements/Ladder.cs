using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Vector2 topPos => (Vector2)transform.position +
                                           Vector2.up * _bound.size.y / 2.0f;

    public Vector2 bottomPos => (Vector2)transform.position +
                                                 Vector2.down * _bound.size.y / 2.0f;

    public Vector2 upStartPos => bottomPos +
                                                 Vector2.up * _ladderUpStartOffsetY;

    public Vector2 upEndPos => topPos +
                                                Vector2.down * _ladderUpEndOffsetY;

    public Vector2 downStartPos => topPos +
                                                      Vector2.down * _ladderDownStartOffsetY;

    public Vector2 downEndPos => bottomPos +
                                                    Vector2.down * _ladderDownEndOffsetY;

    [SerializeField] private float _ladderUpStartOffsetY = 0.1f;
    [SerializeField] private float _ladderUpEndOffsetY = 0.1f;
    [SerializeField] private float _ladderDownStartOffsetY = 0.3f;
    [SerializeField] private float _ladderDownEndOffsetY = 0.3f;
    private BoxCollider2D _bound;

    private void Awake()
    {
        _bound = GetComponent<BoxCollider2D>();
    }

    private void OnDrawGizmos()
    {
        _bound = GetComponent<BoxCollider2D>();

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.left * 0.1f + (Vector3)upStartPos,
                                    Vector3.right * 0.1f + (Vector3)upStartPos);
        Gizmos.DrawLine(Vector3.left * 0.1f + (Vector3)upEndPos,
                                    Vector3.right * 0.1f + (Vector3)upEndPos);

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(Vector3.left * 0.1f + (Vector3)downStartPos,
                                    Vector3.right * 0.1f + (Vector3)downStartPos);
        Gizmos.DrawLine(Vector3.left * 0.1f + (Vector3)downEndPos,
                                    Vector3.right * 0.1f + (Vector3)downEndPos);
    }
}
