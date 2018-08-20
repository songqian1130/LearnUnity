package com.hzy.libp7zip;

import com.unity3d.player.UnityPlayer;

/**
 * Created by huzongyao on 17-7-5.
 */

public class P7ZipApi {

    public static native String get7zVersionInfo();
    public static native int executeCommand(String command);
    public static native int executeCmd(String command,ExtractCallback callback);

    public static void extract7zForUnity(String src,String dst,final String callbackObjName)
    {
        final String cmd = String.format("7z x '%s' '-o%s' -aoa", src, dst);
        Runnable runnable = new Runnable() {
            @Override
            public void run() {
                 int res = executeCmd(cmd,new ExtractCallback(){
                    @Override
                    public void onPercent(String p) {
                        UnityPlayer.UnitySendMessage(callbackObjName,"onExtractPercent",p);
                    }
                });

                 if(res==0)
                 {
                     UnityPlayer.UnitySendMessage(callbackObjName,"onExtractSucceed","");
                 }
                 else
                 {
                     UnityPlayer.UnitySendMessage(callbackObjName,"onExtractError",String.valueOf(res));
                 }
            }
        };
        new Thread(runnable).start();
    }

    static {
        System.loadLibrary("p7zip");
    }
}
