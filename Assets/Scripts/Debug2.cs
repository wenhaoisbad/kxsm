using UnityEngine;
using System.Collections;

public class Debug2 : MonoBehaviour {

//	public UILabel m_FPS;  
    float _updateInterval = 1f;//设定更新帧率的时间间隔为1秒   
    float _accum = .0f;//累积时间   
    int _frames = 0;//在_updateInterval时间内运行了多少帧   
    float _timeLeft;  
  
    void Start () {  
 //       if(!m_FPS){  
 //           enabled = false;  
 //           return;  
 //       }  
        _timeLeft = _updateInterval;  
    //    Debug的getMemoryInfo
       
    }  
      
    // Update is called once per frame   
    void Update()
    {
        _timeLeft -= Time.deltaTime;
        //Time.timeScale可以控制Update 和LateUpdate 的执行速度,   
        //Time.deltaTime是以秒计算，完成最后一帧的时间   
        //相除即可得到相应的一帧所用的时间   
        _accum += Time.timeScale / Time.deltaTime;
        ++_frames;//帧数   

        if (_timeLeft <= 0)
        {
            float fps = _accum / _frames;
            //Debug.Log(_accum + "__" + _frames);   
            string fpsFormat = System.String.Format("fps: {0:F2}", fps);//保留两位小数   

            string memory = GetMemoryInfo();//保留两位小数   
      //      m_FPS.text = fpsFormat+"\n"+memory;

            _timeLeft = _updateInterval;
            _accum = .0f;
            _frames = 0;
        }
    }


    public const float m_KBSize = 1024.0f * 1024.0f;
    public string GetMemoryInfo()
    {
        float totalMemory = (float)(Profiler.GetTotalAllocatedMemory() / m_KBSize);
        float totalReservedMemory = (float)(Profiler.GetTotalReservedMemory() / m_KBSize);
        float totalUnusedReservedMemory = (float)(Profiler.GetTotalUnusedReservedMemory() / m_KBSize);
        float monoHeapSize = (float)(Profiler.GetMonoHeapSize() / m_KBSize);
        float monoUsedSize = (float)(Profiler.GetMonoUsedSize() / m_KBSize);


        return string.Format("chhh:TotalAllocatedMemory：{0}MB\n TotalReservedMemory：{1}MB\nTotalUnusedReservedMemory:{2}MB\n MonoHeapSize:{3}MB\n MonoUsedSize:{4}MB", totalMemory, totalReservedMemory, totalUnusedReservedMemory, monoHeapSize, monoUsedSize);


    }
}
