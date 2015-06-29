using UnityEngine;
using System.Collections;

public class NTMath  {
    public const float Degtorad = 2 * Mathf.PI / 360;//角度转弧度
    /**
     * 极坐标位移
     **/
    public static Vector3 PolarProjection(Vector3 source, float dist, float angle)
    {
        float x = source.x + dist * Mathf.Cos(angle * Degtorad);
        float y = source.y + dist * Mathf.Sin(angle * Degtorad);
        return new Vector3(x, y, source.z);
    }
    /**
     * 两点间方向
     **/
    public static float AngleBetweenVector3(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2( b.x - a.x,b.z - a.z)*Mathf.Rad2Deg;
    }
    /**
     * 以v3为中心，宽width,高height的矩形区域
     * */
    public static Rect RectFromCenterSize(Vector3 v3, float width, float height)
    {
        float x = v3.x;
        float y = v3.z;
        return new Rect(x - width * 0.5f, y - height * 0.5f, x + width * 0.5f, y + height * 0.5f);
    }
}
