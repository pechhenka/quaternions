using UnityEngine;

[ExecuteAlways]
public class Controller : MonoBehaviour
{
    [Header("Параметры кватерниона")]
    [Tooltip("Объект, который задаёт ось вращения")]public Transform Vector;
    [Tooltip("Угол (в радианах)")] public float Angel;

    [Header("Управляемый объект")]
    [Tooltip("Объект, которому задаём вращение")] public GameObject RotationObject;

    void Update()
    {
        Vector3 v = Vector.position - RotationObject.transform.position;

        ShowDebug(v);
        
        RotationObject.transform.rotation = GetQuaternion(v,Angel);
    }

    Quaternion GetQuaternion(in Vector3 vector, in float Angel)
    {
        Vector3 v = vector.normalized;
        float t = Mathf.Sin(Angel / 2);
        return new Quaternion(t * v.x, t * v.y, t * v.z, Mathf.Cos(Angel / 2));
    }

    void ShowDebug(in Vector3 v)
    {
        Debug.DrawLine(RotationObject.transform.position, Vector.position - RotationObject.transform.position); // ось
        Debug.DrawLine(Vector3.zero, v.normalized, Color.red); // нормализация
    }
}
