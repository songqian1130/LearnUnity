#ifndef __P7ZIP_UNITY_H__
#define __P7ZIP_UNITY_H__

class p7zip
{
public:
    int extract7z_ios(const char* srcPath,const char* destPath,const char* callbackObjName);
    int extract7zForUnity(char* srcPath,char* destPath,char* callbackObjName);
private:
};


#ifdef __cplusplus
extern "C" {
#endif
    
    int isDone();
    int extract7z(const char* srcPath,const char* destPath,const char* callbackObjName);
    int extract7zForUnity(const char* srcPath,const char* destPath,const char* callbackObjName,
                          void* onExtractPercent,void* onExtractSucceed,void* onExtractError );
    
#ifdef __cplusplus
}
#endif

#endif
