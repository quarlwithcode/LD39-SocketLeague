using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Chord : MonoBehaviour
{
    #region Variables
    private LineRenderer lr;
    [SerializeField] private GameObject player;
    #endregion

    #region MonoBehaviors
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        transform.LookAt(player.transform);
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, player.transform.position);
    }
    #endregion
}
