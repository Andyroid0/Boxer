using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Box))]
public class BoxGizmo : Editor
{
    [DrawGizmo(GizmoType.InSelectionHierarchy | GizmoType.NotInSelectionHierarchy)]
    private static void DrawRectangleGizmo(Box box, GizmoType gizmoType)
    {
        var color = box.color switch
        {
            BoxColor.Red => Color.red,
            BoxColor.Green => Color.green,
            BoxColor.Blue => Color.blue,
            BoxColor.Cyan => Color.cyan,
            BoxColor.Magenta => Color.magenta,
            _ => Color.green
        };

        Gizmos.color = color;

        var position = box.transform.position;
        var topLeft = position + new Vector3(-box.rect.width / 2, box.rect.height / 2, 0);
        var topRight = position + new Vector3(box.rect.width / 2, box.rect.height / 2, 0);
        var bottomLeft = position + new Vector3(-box.rect.width / 2, -box.rect.height / 2, 0);
        var bottomRight = position + new Vector3(box.rect.width / 2, -box.rect.height / 2, 0);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
