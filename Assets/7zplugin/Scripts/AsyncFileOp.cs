using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AsyncFileOp
{
    public class FileAsyncState
    {
        public Stream src;
        public Stream dst;
        public bool autoClose;
        public const int MAX_READ = 1024 * 256;
        public byte[] buffer = new byte[MAX_READ];

        public bool isDone = false;

        public FileAsyncState(Stream _src, Stream _dst, bool _autoClose)
        {
            src = _src;
            dst = _dst;
            autoClose = _autoClose;
        }
    }
    public static void CopyAsync(FileAsyncState state)
    {
        state.src.BeginRead(state.buffer, 0, FileAsyncState.MAX_READ, ReadAsyncCallback, state);
    }

    private static void ReadAsyncCallback(IAsyncResult ar)
    {
        FileAsyncState state = ar.AsyncState as FileAsyncState;
        int length = state.src.EndRead(ar);
        state.dst.Write(state.buffer, 0, length);
        if (length < FileAsyncState.MAX_READ)
        {
            if (state.autoClose)
            {
                state.src.Close();
                state.dst.Close();
            }
            state.isDone = true;
            return;
        }

        state.src.BeginRead(state.buffer, 0, FileAsyncState.MAX_READ, ReadAsyncCallback, state);
    }
}