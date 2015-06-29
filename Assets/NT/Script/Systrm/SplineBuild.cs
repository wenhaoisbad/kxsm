using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SplineBuild
{
    public static List<Vector3> InterpolateCR(Transform[] pathPts, int slices, 
        float minInterpolateDist = 0.2f)
    {
        int curIndex = 0;
        List<Vector3> outputs=new List<Vector3>();
        outputs.Add(pathPts[0].position);

        int stepCount = slices + 1;
        float minSqrDis = minInterpolateDist * minInterpolateDist;

        for (int i = 0; i < pathPts.Length; ++i)
        {
            Vector3 p0 = pathPts[curIndex].position;
            if (curIndex > 0)
            {
                p0 = pathPts[curIndex - 1].position;
            }

            Vector3 p1 = pathPts[curIndex].position;
            Vector3 p2 = p1;
            int p2Index = curIndex < pathPts.Length - 1 ? curIndex + 1 : curIndex;
            p2 = pathPts[p2Index].position;

            if (p2Index == curIndex)
            {
                // the same point
                outputs.Add(p1);
                ++curIndex;
                continue;
            }

            float sqrDist = Vector3.SqrMagnitude(p1 - p2);
            if (sqrDist < minSqrDis)
            {
                // too close.
                outputs.Add(p1);
                outputs.Add(p2);
                ++curIndex;
                continue;
            }

            Vector3 p3 = p2;
            if (curIndex < pathPts.Length - 2)
            {
                p3 = pathPts[curIndex + 2].position;
            }

            for (int step = 1; step <= stepCount; step++)
            {
                Vector3 v = CatmullRom(p0, p1, p2, p3, (float)step, (float)stepCount);
                outputs.Add(v);
            }
            //ComputeCenteriprtalCR(p0, p1, p2, p3, slices, outputs);

            ++curIndex;
        }
        return outputs;
    }

    public static Vector3 CatmullRom(Vector3 previous, Vector3 start, Vector3 end, Vector3 next,
                                float elapsedTime, float duration)
    {
        float percentComplete = elapsedTime / duration;
        float percentCompleteSquared = percentComplete * percentComplete;
        float percentCompleteCubed = percentCompleteSquared * percentComplete;

        return previous * (-0.5f * percentCompleteCubed +
                                   percentCompleteSquared -
                            0.5f * percentComplete) +
                start * (1.5f * percentCompleteCubed +
                           -2.5f * percentCompleteSquared + 1.0f) +
                end * (-1.5f * percentCompleteCubed +
                            2.0f * percentCompleteSquared +
                            0.5f * percentComplete) +
                next * (0.5f * percentCompleteCubed -
                            0.5f * percentCompleteSquared);
    }

    public class CubicPlyPhase
    {
        public float c0, c1, c2, c3;

        public float Evaluate(float t)
        {
            float t2 = t * t;
            float t3 = t2 * t;
            return c0 + c1 * t + c2 * t2 + c3 * t3;
        }

        public void Initialize(float x0, float x1, float x2, float x3, float dt0, float dt1, float dt2)
        {
            // compute tangents when parameterized in [t1,t2]
            float t1 = (x1 - x0) / dt0 - (x2 - x0) / (dt0 + dt1) + (x2 - x1) / dt1;
            float t2 = (x2 - x1) / dt1 - (x3 - x1) / (dt1 + dt2) + (x3 - x2) / dt2;

            // rescale tangents for parametrization in [0,1]
            t1 *= dt1;
            t2 *= dt1;

            c0 = x0;
            c1 = t1;
            c2 = -3 * x0 + 3 * x1 - 2 * t1 - t2;
            c3 = 2 * x0 - 2 * x1 + t1 + t2;
        }
    }

    public static void ComputeCenteriprtalCR(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, int slices, List<Vector3> pts)
    {
        CubicPlyPhase px = new CubicPlyPhase();
        CubicPlyPhase py = new CubicPlyPhase();
        CubicPlyPhase pz = new CubicPlyPhase();

        float dt0 = Mathf.Pow(Vector3.SqrMagnitude(p0 - p1), 0.25f);
        float dt1 = Mathf.Pow(Vector3.SqrMagnitude(p1 - p2), 0.25f);
        float dt2 = Mathf.Pow(Vector3.SqrMagnitude(p2 - p3), 0.25f);

        // safety check for repeated points
        if (dt1 < 1e-4f) dt1 = 1.0f;
        if (dt0 < 1e-4f) dt0 = dt1;
        if (dt2 < 1e-4f) dt2 = dt1;

        px.Initialize(p0.x, p1.x, p2.x, p3.x, dt0, dt1, dt2);
        py.Initialize(p0.y, p1.y, p2.y, p3.y, dt0, dt1, dt2);
        pz.Initialize(p0.z, p1.z, p2.z, p3.z, dt0, dt1, dt2);

        float dt = 1.0f / (float)slices;
        float t = 0;
        for (int i = 0; i < slices; ++i)
        {
            Vector3 v = Vector3.zero;
            v.x = px.Evaluate(t);
            v.y = py.Evaluate(t);
            v.z = pz.Evaluate(t);
            t += dt;

            pts.Add(v);
        }
    }



    
}

public static class UtilExtensions
{
    public static Color SetAlpha(this Color c, float alpha)
    {
        Color b = c;
        b.a = alpha;
        return b;
    }

    static public bool IsActive(this GameObject go)
    {
        return go && go.activeInHierarchy;
    }

    static public T ForceGetComponent<T>(this GameObject g) where T : Component
    {
        T c = g.GetComponent<T>();
        if (c == null)
        {
            c = g.AddComponent<T>();
        }
        return c;
    }

    static public List<T> GetCompoentHierarchy<T>(this GameObject g) where T : Component
    {
        List<T> list = new List<T>();
        T[] c = g.GetComponents<T>();
        list.AddRange(c); ;
        T[] cs = g.GetComponentsInChildren<T>();
        list.AddRange(cs);

        return list;
    }
}

