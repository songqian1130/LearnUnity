using UnityEngine;
using System.IO;
using System.Collections;

public class ExtractResource : MonoBehaviour
{

    public void Begin()
	{
        ExtractResouce();
    }

    public void ExtractResouce()
    {
        StartCoroutine(ExtractResourceCoroutine());
    }

    public enum ExtractState
    {
        NotStart, 
        ING,
        Complete
    }

    private Stream _writeStream = null;
    private Stream _readStream = null;
    private AsyncFileOp.FileAsyncState _fileAsyncState = null;
    private ExtractState _extractState = ExtractState.NotStart;

    private const string _compressUpdaterFile = "CompressUpdater.7z";


    public IEnumerator ExtractResourceCoroutine()
    {
        var _7zPath = Path.Combine(Application.persistentDataPath, _compressUpdaterFile);
        if(File.Exists(_7zPath))
        {
            File.Delete(_7zPath);
        }

        BetterStreamingAssets.Initialize();

        _writeStream = new FileStream(_7zPath, FileMode.CreateNew);

        _readStream = BetterStreamingAssets.OpenRead(_compressUpdaterFile);

        _fileAsyncState = new AsyncFileOp.FileAsyncState(_readStream, _writeStream, true);


		AsyncFileOp.CopyAsync(_fileAsyncState);

        while(true)
        {
            if(_fileAsyncState.isDone)
            {
                var path1 = Path.Combine(Application.persistentDataPath, _compressUpdaterFile);
                _extractState = ExtractState.ING;
                plugin_7z.Extract7z(path1,Application.persistentDataPath,this.gameObject.name);

                break;
            }

            yield return null;
        }
    }

	#region 上层回调
	public void onExtractSucceed(string msg)
    {
		Debug.Log("Extract Finish!" + " Path: " + Application.persistentDataPath);

		_percent = 1;

		//TODO
		//解压完成后续事件
    }

    public void onExtractError(string msg)
    {
	    
    }

    private float _percent = 0;

    public void onExtractPercent(string msg)
    {
        if (msg.Contains("%"))
        {
            _percent = float.Parse(msg.Substring(0,msg.Length-1));
            _percent = _percent / 100.0f;
            if (_percent > 0)
            {
				Debug.Log(_percent);
            }
        }
	   
    }
	#endregion
}