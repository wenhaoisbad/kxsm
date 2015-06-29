using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveOnPath : MonoBehaviour {

    public struct Pt
    {
        public Vector3 Pos;
        public Vector3 MotionDir;
        public Quaternion Rot;
        public float Duration;
    }

    public float InitialVeloc = 1;
    public float Acceleration = 0;

    System.Action<MoveOnPath> mCallbackOnFinished = null;
    List<Pt> mPts = new List<Pt>();
    float mCurrentVeloc = 0;
    float mElapsed = 0;
    int mCurrentPtIndex = 0;
    bool mMoving = false;

    public bool Moving
    {
        get
        {
            return mMoving;
        }
    }

	
	// Update is called once per frame
	void Update () {

        if(mMoving)
        {
            float dt = Time.deltaTime;
            mCurrentVeloc += Acceleration * dt;

            Pt p1 = mPts[mCurrentPtIndex];
            Pt p2 = mPts[mCurrentPtIndex + 1];

            mElapsed += dt;

            if (mElapsed >= p1.Duration)
            {
         //       transform.position = p2.Pos;
                transform.rotation = p2.Rot;

                ++mCurrentPtIndex;
                mElapsed -= p1.Duration;

                if (mCurrentPtIndex >= mPts.Count - 1)
                {
                    mMoving = false;

                    if (mCallbackOnFinished != null)
                    {
                        mCallbackOnFinished(this);
                    }
                }
                else
                {
                    Vector3 offset = p2.MotionDir * mCurrentVeloc * mElapsed;
             //       transform.position = transform.position + offset;
                }
            }
            else
            {
                float t = mElapsed / p1.Duration;
                t = Mathf.Clamp(t, 0f, 1f);
                Quaternion rot = Quaternion.Lerp(p1.Rot, p2.Rot, t);
                Vector3 offset = p1.MotionDir * mCurrentVeloc * dt;
                //transform.Translate(offset, Space.World);
        //        transform.position = transform.position + offset;
                transform.rotation = rot;
            }
        }
	}

    public void StartOnPath(List<Vector3> pathPts, System.Action<MoveOnPath> onFinished = null)
    {
        if (pathPts.Count < 2)
        {
            Debug.LogError("Number of path points less than 2!");
            return;
        }

        Pt pt;
        pt.Pos = Vector3.zero;
        pt.MotionDir = Vector3.forward;
        pt.Rot = Quaternion.identity;
        pt.Duration = 0;
        float v = InitialVeloc;

        for (int i = 0; i < pathPts.Count; ++i)
        {
            pt.Pos = pathPts[i];
            pt.Duration = 0.1f;//持续
            if (i < pathPts.Count - 1)
            {
                Vector3 dir = pathPts[i + 1] - pathPts[i];
                pt.MotionDir = dir.normalized;
                pt.Rot = Quaternion.LookRotation(pt.MotionDir, Vector3.up);

                float s = dir.magnitude;
                if (Acceleration != 0)
                {
                    //FIXME
                    pt.Duration = (Mathf.Sqrt(v * v + 2.0f * Acceleration * s) - v) / Acceleration; //加速
                }
                else
                {
                    pt.Duration = s / v;//匀速
                }

                v += Acceleration * pt.Duration;
            }
            else
            {
                pt.Rot = mPts[mPts.Count - 1].Rot;
            }

            if(pt.Duration > 0)
                mPts.Add(pt);
        }

        mCurrentPtIndex = 0;
        mCurrentVeloc = InitialVeloc;
        mElapsed = 0;
        mMoving = true;
        mCallbackOnFinished = onFinished;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red.SetAlpha(0.5f);
        foreach (Pt p in mPts)
        {
            Gizmos.DrawSphere(p.Pos, 0.2f);
        }
    }
}
