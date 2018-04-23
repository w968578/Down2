using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponFloat : MonoBehaviour {
    [SerializeField] Vector3 asHighAs;
    [SerializeField] Vector3 asLowAs;
    private void Start()
    {
        StartCoroutine(Floating(asLowAs));
    }

    IEnumerator Floating(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.2f) {
            Vector3 direction = target.y == asHighAs.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * 2*Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds (0.1f);

        Vector3 newTarget = target.y == asHighAs.y ? asLowAs : asHighAs;

        StartCoroutine(Floating(newTarget));
    }
}
