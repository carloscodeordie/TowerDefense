using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;

    void Update()
    {
        Vector3 snapPos = CalculateGridPosition();
        this.transform.position = snapPos;
    }

    private Vector3 CalculateGridPosition()
    {
        float posX = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        float posZ = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        return new Vector3(posX, 0f, posZ);
    }
}
