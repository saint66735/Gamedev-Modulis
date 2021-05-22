using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benchmark_Controller : MonoBehaviour
{
    public List<Transform> benchmarkSpots;
    [SerializeField]
    float speed = 10;
    Coroutine MoveIE;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveTowards());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator MoveTowards()
    {
        //transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * speed);
        //Debug.Log("My destination " + t.position);
        //yield return null;
        for (int i = 0; i < benchmarkSpots.Count; i++)
        {
            MoveIE = StartCoroutine(Moving(i));
            Debug.Log(i);
            yield return MoveIE;
        }
    }
    IEnumerator Moving(int currentPos)
    {
        Debug.Log("movin");
        while (!transform.position.Equals(benchmarkSpots[currentPos]))
        {
            transform.position = Vector3.MoveTowards(transform.position, benchmarkSpots[currentPos].position, speed * Time.deltaTime);
            yield return null;
        }
    }
}
