
using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class plugin_7z
{
#if UNITY_IOS
    [DllImport("__Internal")]private static extern void p7zip_extract7z(string src,string dst,string callbackObjName);
#endif
    public static void Extract7z(string inPath,string outPath)
    {
#if UNITY_ANDROID
        var _extractCmd = string.Format("7z x '{0}' '-o{1}' -aoa", inPath, outPath);
        executeCmd(_extractCmd);
#elif UNITY_IOS

#endif
    }

    public static void Extract7z(string inPath, string outPath, string callbackGameObjName)
    {
#if UNITY_ANDROID
        //using (AndroidJavaClass Un7ZipApi = new AndroidJavaClass("com.hzy.lib7z.Z7Extractor"))
        //{
        //    Un7ZipApi.CallStatic("extractFileForUnity",inPath,outPath,callbackGameObjName);
        //}
        using (AndroidJavaClass p7ZipApi = new AndroidJavaClass("com.hzy.libp7zip.P7ZipApi"))
        {
            p7ZipApi.CallStatic("extract7zForUnity",inPath,outPath,callbackGameObjName);
        }
#elif UNITY_IOS
        p7zip_extract7z(inPath, outPath, callbackGameObjName);
#endif
    }

    //z x "d:\File.7z" -y -aos -o"d:\Mydir"
    private static void executeCmd(string cmd)
    {
        using (AndroidJavaClass P7ZipApi = new AndroidJavaClass("com.hzy.libp7zip.P7ZipApi_Java"))
        {
            if (null == P7ZipApi)
            {
                Debug.Log("P7ZipApi_Java == null");
            }
            else
            {
                Debug.LogError("P7ZipApi.CallStatic<int>(executeCommand,cmd);" + cmd);
                P7ZipApi.CallStatic("executeCommand", cmd);
            }
        }
    }

    public static int getFutureTaskResult()
    {
#if UNITY_ANDROID
        using (AndroidJavaClass P7ZipApi = new AndroidJavaClass("com.hzy.libp7zip.P7ZipApi_Java"))
        {
            if (null == P7ZipApi)
            {
                Debug.Log("P7ZipApi_Java == null");
            }
            else
            {
                return P7ZipApi.CallStatic<int>("getFutureTaskResult");
            }
        }
#endif
        return -100;
    }
    
    public static bool isDone()
    {
#if UNITY_ANDROID
        using (AndroidJavaClass P7ZipApi = new AndroidJavaClass("com.hzy.libp7zip.P7ZipApi_Java"))
        {
            if (null == P7ZipApi)
            {
                Debug.Log("P7ZipApi_Java == null");
            }
            else
            {
                return P7ZipApi.CallStatic<bool>("isDone");
            }
        }
#endif
        return false;
    }

    public static float getPercent()
    {
        using (AndroidJavaClass P7ZipApi = new AndroidJavaClass("com.hzy.libp7zip.P7ZipApi"))
        {
            if (null == P7ZipApi)
            {
                Debug.Log("P7ZipApi == null");
            }
            else
            {
                return P7ZipApi.CallStatic<float>("getPercent");
            }
        }
        return -1;
    }

    public static long getTotalSize()
    {
        using (AndroidJavaClass P7ZipApi = new AndroidJavaClass("com.hzy.libp7zip.P7ZipApi"))
        {
            if (null == P7ZipApi)
            {
                Debug.Log("P7ZipApi == null");
            }
            else
            {
                return P7ZipApi.CallStatic<long>("getTotalSize");
            }
        }
        return -1;
    }

    public static long getCompletedSize()
    {
        using (AndroidJavaClass P7ZipApi = new AndroidJavaClass("com.hzy.libp7zip.P7ZipApi"))
        {
            if (null == P7ZipApi)
            {
                Debug.Log("P7ZipApi == null");
            }
            else
            {
                return P7ZipApi.CallStatic<long>("getCompletedSize");
            }
        }
        return -1;
    }


}