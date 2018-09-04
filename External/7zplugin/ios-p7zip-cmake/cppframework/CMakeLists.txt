cmake_minimum_required (VERSION 3.7)

include_directories(
  ${CMAKE_CURRENT_LIST_DIR}/CPP/myWindows
  ${CMAKE_CURRENT_LIST_DIR}/CPP
  ${CMAKE_CURRENT_LIST_DIR}/CPP/include_windows
  ${CMAKE_CURRENT_LIST_DIR}/C
)
add_definitions( -D_FILE_OFFSET_BITS=64 -D_LARGEFILE_SOURCE -D_REENTRANT -DENV_UNIX -DBREAK_HANDLER -DUNICODE -D_UNICODE -DUNIX_USE_WIN_FILE)

set(LIBRARY_SOURCE
	${CMAKE_CURRENT_LIST_DIR}/OC/p7zip_oc.h
    ${CMAKE_CURRENT_LIST_DIR}/OC/p7zip_oc.mm
    ${CMAKE_CURRENT_LIST_DIR}/p7zip_unity.h
    ${CMAKE_CURRENT_LIST_DIR}/p7zip_unity.cpp
    ${CMAKE_CURRENT_LIST_DIR}/C/7zCrc.c
    ${CMAKE_CURRENT_LIST_DIR}/C/7zCrcOpt.c
    ${CMAKE_CURRENT_LIST_DIR}/C/7zStream.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Aes.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Alloc.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Bcj2.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Bcj2Enc.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Bra.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Bra86.c
    ${CMAKE_CURRENT_LIST_DIR}/C/BraIA64.c
    ${CMAKE_CURRENT_LIST_DIR}/C/BwtSort.c
    ${CMAKE_CURRENT_LIST_DIR}/C/CpuArch.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Delta.c
    ${CMAKE_CURRENT_LIST_DIR}/C/HuffEnc.c
    ${CMAKE_CURRENT_LIST_DIR}/C/LzFind.c
    ${CMAKE_CURRENT_LIST_DIR}/C/LzFindMt.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Lzma2Dec.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Lzma2Enc.c
    ${CMAKE_CURRENT_LIST_DIR}/C/LzmaDec.c
    ${CMAKE_CURRENT_LIST_DIR}/C/LzmaEnc.c
    ${CMAKE_CURRENT_LIST_DIR}/C/MtCoder.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Ppmd7.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Ppmd7Dec.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Ppmd7Enc.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Ppmd8.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Ppmd8Dec.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Ppmd8Enc.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Sha1.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Sha256.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Sort.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Threads.c
    ${CMAKE_CURRENT_LIST_DIR}/C/Xz.c
    ${CMAKE_CURRENT_LIST_DIR}/C/XzCrc64.c
    ${CMAKE_CURRENT_LIST_DIR}/C/XzCrc64Opt.c
    ${CMAKE_CURRENT_LIST_DIR}/C/XzDec.c
    ${CMAKE_CURRENT_LIST_DIR}/C/XzEnc.c
    ${CMAKE_CURRENT_LIST_DIR}/C/XzIn.c
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zCompressionMode.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zDecode.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zEncode.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zExtract.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zFolderInStream.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zHandler.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zHandlerOut.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zHeader.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zIn.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zOut.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zProperties.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zRegister.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zSpecStream.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/7z/7zUpdate.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Bz2Handler.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Cab/CabBlockInStream.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Cab/CabHandler.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Cab/CabHeader.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Cab/CabIn.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Cab/CabRegister.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Common/CoderMixer2.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Common/DummyOutStream.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Common/FindSignature.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Common/HandlerOut.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Common/InStreamWithCRC.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Common/ItemNameUtils.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Common/MultiStream.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Common/OutStreamWithCRC.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Common/ParseProperties.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/DeflateProps.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/GzHandler.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/LzmaHandler.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/PpmdHandler.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/SplitHandler.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Tar/TarHandler.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Tar/TarHandlerOut.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Tar/TarHeader.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Tar/TarIn.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Tar/TarOut.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Tar/TarRegister.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Tar/TarUpdate.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/XzHandler.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/ZHandler.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Zip/ZipAddCommon.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Zip/ZipHandler.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Zip/ZipHandlerOut.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Zip/ZipIn.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Zip/ZipItem.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Zip/ZipOut.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Zip/ZipRegister.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Archive/Zip/ZipUpdate.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/CWrappers.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/CreateCoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/FilePathAutoRename.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/FileStreams.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/FilterCoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/InBuffer.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/InOutTempBuffer.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/LimitedStreams.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/MemBlocks.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/MethodId.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/MethodProps.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/OffsetStream.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/OutBuffer.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/OutMemStream.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/ProgressMt.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/ProgressUtils.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/PropId.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/StreamBinder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/StreamObjects.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/StreamUtils.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/UniqBlocks.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Common/VirtThread.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/BZip2Crc.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/BZip2Decoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/BZip2Encoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/BZip2Register.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/Bcj2Coder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/Bcj2Register.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/BcjCoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/BcjRegister.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/BitlDecoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/BranchMisc.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/BranchRegister.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/ByteSwap.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/CopyCoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/CopyRegister.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/Deflate64Register.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/DeflateDecoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/DeflateEncoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/DeflateRegister.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/DeltaFilter.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/ImplodeDecoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/ImplodeHuffmanDecoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/LzOutWindow.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/Lzma2Decoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/Lzma2Encoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/Lzma2Register.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/LzmaDecoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/LzmaEncoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/LzmaRegister.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/LzxDecoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/PpmdDecoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/PpmdEncoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/PpmdRegister.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/PpmdZip.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/QuantumDecoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/ShrinkDecoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Compress/ZDecoder.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Crypto/7zAes.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Crypto/7zAesRegister.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Crypto/HmacSha1.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Crypto/MyAes.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Crypto/MyAesReg.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Crypto/Pbkdf2HmacSha1.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Crypto/RandGen.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Crypto/WzAes.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Crypto/ZipCrypto.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/Crypto/ZipStrong.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/ArchiveCommandLine.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/ArchiveExtractCallback.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/ArchiveOpenCallback.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/Bench.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/DefaultName.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/EnumDirItems.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/Extract.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/ExtractingFilePath.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/HashCalc.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/LoadCodecs.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/OpenArchive.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/PropIDUtils.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/SetProperties.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/SortUtils.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/TempFiles.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/Update.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/UpdateAction.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/UpdateCallback.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/UpdatePair.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Common/UpdateProduce.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Console/BenchCon.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Console/ConsoleClose.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Console/ExtractCallbackConsole.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Console/HashCon.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Console/List.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Console/Main.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Console/MainAr.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Console/OpenCallbackConsole.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Console/PercentPrinter.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Console/UpdateCallbackConsole.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/7zip/UI/Console/UserInputUtils.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/CRC.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/CommandLineParser.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/CrcReg.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/IntToString.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/ListFileUtils.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/MyString.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/MyVector.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/MyWindows.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/Sha1Reg.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/Sha256Reg.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/StdInStream.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/StdOutStream.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/StringConvert.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/StringToInt.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/UTFConvert.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/Wildcard.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Common/XzCrc64Reg.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Windows/ErrorMsg.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Windows/FileDir.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Windows/FileFind.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Windows/FileIO.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Windows/FileName.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Windows/PropVariant.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Windows/PropVariantConv.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Windows/Synchronization.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Windows/System.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/Windows/TimeUtils.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/myWindows/myAddExeFlag.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/myWindows/mySplitCommandLine.cpp
    ${CMAKE_CURRENT_LIST_DIR}/CPP/myWindows/wine_date_and_time.cpp
)

add_library(
    ${FRAMEWORK_NAME} SHARED
    ${LIBRARY_SOURCE}
)

set(CMAKE_SHARED_LINKER_FLAGS "-Wall")

set_target_properties(${FRAMEWORK_NAME} PROPERTIES
    FRAMEWORK TRUE
    FRAMEWORK_VERSION A
    MACOSX_FRAMEWORK_IDENTIFIER ${FRAMEWORK_BUNDLE_IDENTIFIER}
    MACOSX_FRAMEWORK_INFO_PLIST ${CMAKE_CURRENT_LIST_DIR}/framework.plist.in
    # "current version" in semantic format in Mach-O binary file
    VERSION 1.0.0
    # "compatibility version" in semantic format in Mach-O binary file
    SOVERSION 1.0.0
    PUBLIC_HEADER "${CMAKE_CURRENT_LIST_DIR}/p7zip_unity.h"
    XCODE_ATTRIBUTE_IPHONEOS_DEPLOYMENT_TARGET ${DEPLOYMENT_TARGET}
    XCODE_ATTRIBUTE_CODE_SIGN_IDENTITY ${CODE_SIGN_IDENTITY}
    XCODE_ATTRIBUTE_DEVELOPMENT_TEAM ${DEVELOPMENT_TEAM_ID}
    XCODE_ATTRIBUTE_TARGETED_DEVICE_FAMILY ${DEVICE_FAMILY}
    XCODE_ATTRIBUTE_SKIP_INSTALL "YES"
    XCODE_ATTRIBUTE_ENABLE_BITCODE "NO"
)

# Symbol visibility setup, COMPILE_FLAGS only affect C++ so for Objective C we
# have to use XCODE_ATTRIBUTE_OTHER_CFLAGS.
set_target_properties(${FRAMEWORK_NAME} PROPERTIES
    COMPILE_FLAGS "-fvisibility=hidden -fvisibility-inlines-hidden"
    XCODE_ATTRIBUTE_OTHER_CFLAGS "-fvisibility=hidden -fvisibility-inlines-hidden")

# set_target_properties(${FRAMEWORK_NAME} PROPERTIES COMPILE_FLAGS "-x c++")

add_custom_command(
    TARGET ${FRAMEWORK_NAME}
    POST_BUILD
    COMMAND /bin/bash -c "${CMAKE_CURRENT_LIST_DIR}/install_name.sh \${BUILT_PRODUCTS_DIR}/\${PRODUCT_NAME}.framework/\${PRODUCT_NAME}"
)

add_custom_command(
    TARGET ${FRAMEWORK_NAME}
    POST_BUILD
    COMMAND install_name_tool -id \"@rpath/\${PRODUCT_NAME}.framework/\${PRODUCT_NAME}\"
    \${BUILT_PRODUCTS_DIR}/\${PRODUCT_NAME}.framework/\${PRODUCT_NAME}
)

