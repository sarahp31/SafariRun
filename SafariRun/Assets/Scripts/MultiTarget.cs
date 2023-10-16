using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTarget : MonoBehaviour{
    public List<Transform> targets;

    public Vector3 offset;

    void LateUpdate() {
        Vector3 centro = Centraliza();

        Vector3 centroNovo = centro + offset;

        centroNovo.y = 0f;

        transform.position = centroNovo;
    }

    Vector3 Centraliza() {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        bounds.Encapsulate(targets[1].position);

        return bounds.center;
    }
}

