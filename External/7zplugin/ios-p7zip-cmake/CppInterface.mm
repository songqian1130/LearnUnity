#import "CppInterface.h"
//#include <FooBar/Foo.hh>

#include "P7zipUnity/p7zip_unity.h"

@interface CppInterface () 
{
    //Foo* myFoo;
}
@end

@implementation CppInterface

-(instancetype)init
{
    self = [super init];
    if (self) {
//        myFoo = new Foo();
//        myFoo->PrintFoo();
//        delete myFoo;
//        myFoo = nullptr;
        [self testBig7Z];
    }
    return self;
}

- (void) testBig7Z
{
    NSString *archiveFilename = @"ZipUpdater.7z";
    NSString *archiveResPath = [[NSBundle mainBundle] pathForResource:archiveFilename ofType:nil];
    NSLog(@"%@",archiveResPath);
    //NSAssert(archiveResPath, @"can't find %@", archiveFilename);
    
    NSArray *paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory,NSUserDomainMask,YES);
    NSString *docPath = [paths objectAtIndex:0];
    
    NSLog(@"docPath: %@",docPath);
    
    NSDate *start = [NSDate date];
    
    //    NSArray *contents = [LZMAExtractor extract7zArchive:archiveResPath
    //                                                dirName: docPath
    //                                            preserveDir:TRUE];
    const char *inPath = [archiveResPath UTF8String];
    const char *outPath = [docPath UTF8String];
//    p7zip * p7 = new p7zip();
//    p7->extract7z_ios(inPath,outPath,"");
    extract7zForUnity(inPath,outPath,"",nullptr,nullptr,nullptr);
    //delete p7;
    
    while (1) {
        sleep(1);
        if(isDone()==1)
        {
            break;
        }
    }
    
    NSTimeInterval timeInterval = [start timeIntervalSinceNow];
    
    NSLog(@"time inteval: %f",timeInterval);
    
    return;
    
    
    NSFileManager *fm = [NSFileManager defaultManager];
    
    NSDirectoryEnumerator *de = [fm enumeratorAtPath:docPath];
    
    NSString *file;
    while (file=[de nextObject]) {
        NSLog(@"%@",file);
    }
    
    return;
}


@end

//extern "C"
//{
//    int extract7z(const char* srcPath,const char* destPath,const char* callbackObjName);
//}
