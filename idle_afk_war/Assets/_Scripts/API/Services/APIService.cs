using System;
using System.IO;
using qtLib.Extension;
using Cysharp.Threading.Tasks;
using qtLib.Helper;
using UnityEngine;

namespace _Scripts.API.Services
{
    public abstract class APIService<T> where T : DataModel, new()
    {
        private string _dataQueue;
        private string _currentData;
        private bool _isSaving;
        private string _dataPath;
        
        protected T _data; 

        protected abstract string DataPath();

        protected APIService()
        {
            _dataQueue = string.Empty;
            _isSaving = false;
            
            LoadData();
        }

        private void LoadData()
        {
            _dataPath = Application.persistentDataPath.PathCombine(DataPath());
            if (!File.Exists(_dataPath))
            {
                CreateDefaultData();
            }
            else
            {
                string data = File.ReadAllText(_dataPath);
                if (string.IsNullOrEmpty(data))
                {
                    CreateDefaultData();
                }
                else
                {
                    try
                    {
                        _data = JsonUtility.FromJson<T>(data);
                    }
                    catch (ArgumentException)
                    {
                        CreateDefaultData();
                    }
                    catch (Exception e)
                    {
                        qtDebug.LogError($"{typeof(T)}: {e.Message}");
                    }
                }
            }
        }

        protected async void SaveData()
        {
            _dataQueue = JsonUtility.ToJson(_data);
            if (_isSaving)
            {
                return;
            }
            
            _isSaving = true;
            
            while (!string.IsNullOrEmpty(_dataQueue))
            {
                _currentData = _dataQueue;
                _dataQueue = string.Empty;
                File.WriteAllText(_dataPath, _currentData);
                await UniTask.Delay(APIManager.API_TimeBetween2TimeSaveData);
            }
            
            _isSaving = false;
        }

        protected virtual void CreateDefaultData()
        {
            _data = new T();
            SaveData();
        }
    }

    [Serializable]
    public class DataModel
    {
        
    }
}