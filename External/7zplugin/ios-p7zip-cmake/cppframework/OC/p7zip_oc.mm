//
//  p7zip_oc.m
//  P7zipUnity
//
//  Created by StarlyGirls on 2018/9/4.
//

#import "p7zip_oc.h"
#import <Foundation/Foundation.h>

void p7zip_log(const char* msg)
{
    NSLog(@"%@", [NSString stringWithUTF8String:msg]);
}
