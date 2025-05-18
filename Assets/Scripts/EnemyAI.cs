using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming
    }

    private State state;
    private EnemyPathfinding enemyPathfinding;
    private Animator animator; // <- Add reference to Animator

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        animator = GetComponent<Animator>(); // <- Get Animator component
        state = State.Roaming;
    }

    private void Start()
    {
        animator.SetBool("IsRoaming", true); // <- Trigger roaming animation
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyAI : MonoBehaviour
// {
//     private enum State {
//         Roaming
//     }

//     private State state;
//     private EnemyPathfinding enemyPathfinding;

//     private void Awake() {
//         enemyPathfinding = GetComponent<EnemyPathfinding>();
//         state = State.Roaming;
//     }

//     private void Start() {
//         StartCoroutine(RoamingRoutine());
//     }

//     private IEnumerator RoamingRoutine() {
//         while (state == State.Roaming)
//         {
//             Vector2 roamPosition = GetRoamingPosition();
//             enemyPathfinding.MoveTo(roamPosition);
//             yield return new WaitForSeconds(2f);
//         }
//     }

//     private Vector2 GetRoamingPosition() {
//         return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
//     }
// }
