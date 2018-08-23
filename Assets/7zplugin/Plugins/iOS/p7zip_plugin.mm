#import <P7ZipUnity/p7zip_unity.h>
#import <string.h>

extern "C"
{
    void p7zip_extract7z(const char *srcPath,const char *dstPath,const char *callbackObjName);
    
    void onExtractPercent(char *msg);
    void onExtractSucceed();
    void onExtractError();
}
extern void UnitySendMessage(const char *, const char *, const char *);

char gCallbackObjName[256];



void onExtractPercent(char *msg)
{
    UnitySendMessage(gCallbackObjName, "onExtractPercent", (const char*)msg);
}

void onExtractSucceed()
{
    UnitySendMessage(gCallbackObjName, "onExtractSucceed", "");
}

void onExtractError()
{
    UnitySendMessage(gCallbackObjName, "onExtractError", "");
}

char gSrcPath[1024];
char gDstPath[1024];

void p7zip_extract7z(const char *srcPath,const char *dstPath,const char *callbackObjName)
{
    strcpy(gCallbackObjName,callbackObjName);
    strcpy(gSrcPath,srcPath);
    strcpy(gDstPath, dstPath);
    extract7zForUnity(gSrcPath,gDstPath,"",(void*)onExtractPercent,(void*)onExtractSucceed,(void*)onExtractError);
}

