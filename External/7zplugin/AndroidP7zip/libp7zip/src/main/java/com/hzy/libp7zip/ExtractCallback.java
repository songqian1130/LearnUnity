package com.hzy.libp7zip;

/**
 * Created by zhou on 2018/5/30.
 */

public abstract class ExtractCallback {
    public void onPercent(String p){}
    public void onSucceed(){}
    public void onError(){}
}
