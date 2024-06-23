using UnityEngine;

public class Deformation : MonoBehaviour
{
    public float DeformForce = 5f;
    public float DeformRadius = 1f;
    public float DeformSpeed = 1f;
    void OnCollisionEnter(Collision other)
    {
        Mesh CurrentMesh = GetComponent<MeshFilter>().mesh; // Get mesh.
        Vector3[] copyMeshVertices = CurrentMesh.vertices; // Copy vertices.


        for (int i = 0; i < copyMeshVertices.Length; i++)
        {
            Rigidbody Rb = GetComponent<Rigidbody>();

            //Vector3 Distance = (copyMeshVertices[i] - transform.InverseTransformPoint(other.GetContact(0).point) );
            Vector3 Distance = (copyMeshVertices[i] - other.GetContact(0).point );
            if (Distance.magnitude < DeformRadius && Rb.velocity.magnitude > DeformSpeed)
            {   
                copyMeshVertices[i] += transform.forward / Rb.velocity.magnitude;

                Destroy(GetComponent<MeshCollider>());
                gameObject.AddComponent<MeshCollider>().convex = true;

                Debug.Log(Rb.velocity.magnitude);
            }
            Debug.DrawRay(transform.position,transform.forward *  5, Color.green);
        }
        CurrentMesh.vertices = copyMeshVertices;
        CurrentMesh.RecalculateBounds();


        //GetComponent<Rigidbody>().useGravity = false;
    }
}
/*
void Deformation(Ray ray)
{
    Mesh deformingMesh = hit.collider.gameObject.GetComponent<MeshFilter>().mesh;

    GameObject deformingGameObject = hit.collider.gameObject;

    //  опируем все вершины меша.
    Vector3[] copyMeshVertices = deformingMesh.vertices;
    // Calculate the transform's position relative to the DeformingGameObject.
    Vector3 hitPointToLocalCoordinatesMesh = deformingGameObject.transform.InverseTransformPoint(hit.point);

    for (int i = 0; i < copyMeshVertices.Length; i++)
    {
        // Ќаходим дистанцию между точкой столкновени€ луча и вершиной меша.
        float _Distance = (float)Vector3.Distance(hitPointToLocalCoordinatesMesh, copyMeshVertices[i]);
        if (RadiusDeform > _Distance)
        {
            copyMeshVertices[i] += ray.direction.normalized * ForceDeform;
        }
    }

    deformingMesh.vertices = copyMeshVertices;
    deformingMesh.RecalculateBounds();
    //deformingMesh.RecalculateNormals();

    Destroy(deformingGameObject.GetComponent<BoxCollider>());
    deformingGameObject.AddComponent<BoxCollider>();
    //deformingGameObject.AddComponent<MeshCollider>().convex = true;
}
*/