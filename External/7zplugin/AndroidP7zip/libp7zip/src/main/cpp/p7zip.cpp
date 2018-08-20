#include <ndkhelper.h>
#include <jni.h>
#include <7zip/MyVersion.h>
#include <cmd/command.h>

#define MY_P7ZIP_VERSION_INFO "7zVersion: "MY_VERSION"\n"MY_COPYRIGHT"\nDate: "MY_DATE

JNIEXPORT jstring JNICALL
Java_com_hzy_libp7zip_P7ZipApi_get7zVersionInfo(JNIEnv *env, jclass type) {
    return env->NewStringUTF(MY_P7ZIP_VERSION_INFO);
}

JNIEXPORT jint JNICALL
Java_com_hzy_libp7zip_P7ZipApi_executeCommand(JNIEnv *env, jclass type, jstring command_) {
    const char *command = env->GetStringUTFChars(command_, 0);
    LOGI("CMD:[%s]", command);
    int ret = executeCommand(command);
    env->ReleaseStringUTFChars(command_, command);
    return ret;
}

jmethodID sOnPercent;
JNIEnv* sEnv;
jobject sCallback;

JNIEXPORT jint JNICALL
Java_com_hzy_libp7zip_P7ZipApi_executeCmd(JNIEnv *env, jclass type, jstring command_,jobject callback_) {
    const char *command = env->GetStringUTFChars(command_, 0);
    LOGI("CMD:[%s]", command);
    sEnv = env;
    sCallback = callback_;
    jclass callbackClass = env->functions->GetObjectClass(env, callback_);
    sOnPercent =
            env->functions->GetMethodID(env, callbackClass, "onPercent", "(Ljava/lang/String;)V");
    int ret = executeCommand(command);
    env->ReleaseStringUTFChars(command_, command);
    return ret;
}

void CallJavaStringMethod(JNIEnv *env, jobject obj, jmethodID id, char *param) {
    jstring jparam = env->functions->NewStringUTF(env, param);
    env->functions->CallVoidMethod(env, obj, id, jparam);
    env->functions->DeleteLocalRef(env, jparam);
}





