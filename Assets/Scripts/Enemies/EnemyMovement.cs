using UnityEngine;
using Pathfinding;
using System.Collections;
using System;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AIPath))]
public class EnemyMovement : MonoBehaviour
{
    public event Action Stopped;
    [SerializeField] private float _searchPointRegion = 2f;
    private AIPath _path;
    private void Start()
    {
        _path = GetComponent<AIPath>();
        //Stopped += SetRandomPosition;
        //SetRandomPosition();
    }
    public void SetRandomPosition()
    {
        Bounds bounds = new Bounds(transform.position, Vector3.one * _searchPointRegion);
        var nodes = AstarPath.active.data.gridGraph.GetNodesInRegion(bounds);
        if(nodes.Count == 0)
        {
            _path.destination = transform.position;
            return;
        }
        var randomNode = nodes[Random.Range(0, nodes.Count)];
        _path.destination = (Vector3)randomNode.position;
        StartCoroutine(CheckDestination());
    }
    //public void StopMove()
    //{
    //    StartCoroutine(Delay());
    //}
    //private IEnumerator Delay()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    SetRandomPosition();
    //}
    private IEnumerator CheckDestination()
    {
        while (!_path.reachedEndOfPath/*Vector3.Distance(transform.position, _path.destination) >= _path.endReachedDistance*/)
        {
            yield return new WaitForSeconds(.5f);
        }
        Stopped?.Invoke();
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawCube(transform.position, Vector3.one * _searchPointRegion);
    //}
}
