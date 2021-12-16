using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using Dummiesman; //namespace for OBJLoader

public class Loading : MonoBehaviour
{

    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _nextButton;
    [SerializeField] private GameObject _loadingScreen;

    private GameObject[] _models;
    private uint _currentModel = 0;

    void Start()
    {
        string inputPath = Application.dataPath + "/Input";

        if (!Directory.Exists(inputPath))
        {
            Directory.CreateDirectory(inputPath);
        }

        string[] pathsToFiles = Directory.GetFiles(inputPath);
        GameObject[] _tmpModels = new GameObject[pathsToFiles.Length];

        int j = 0;
        for(int i = 0; i < pathsToFiles.Length; i++)
        {
            if (Path.GetExtension(pathsToFiles[i]) == ".obj" || Path.GetExtension(pathsToFiles[i]) == ".OBJ")
            {
                //Debug.Log("Loading: " + pathsToFiles[i]);
                if(File.Exists((inputPath + "/" + Path.GetFileNameWithoutExtension(pathsToFiles[i]) + ".mtl")))
                {
                    _tmpModels[j] = new OBJLoader().Load(pathsToFiles[i], (inputPath + "/" + Path.GetFileNameWithoutExtension(pathsToFiles[i]) + ".mtl"));
                }
                else if(File.Exists((inputPath + "/" + Path.GetFileNameWithoutExtension(pathsToFiles[i]) + ".MTL")))
                {
                    _tmpModels[j] = new OBJLoader().Load(pathsToFiles[i], (inputPath + "/" + Path.GetFileNameWithoutExtension(pathsToFiles[i]) + ".MTL"));
                }
                else
                {
                    _tmpModels[j] = new OBJLoader().Load(pathsToFiles[i]);
                }

                _tmpModels[j].transform.SetParent(this.transform);
                _tmpModels[j].transform.position = Vector3.zero;
                _tmpModels[j].transform.rotation = Quaternion.identity;
                _tmpModels[j].SetActive(false);

                j++;
            }
            
        }

        _models = new GameObject[j];
        for (int i = 0; i < _models.Length; i++)
        {
            _models[i] = _tmpModels[i];
        }

        ShowModel(0);
        _loadingScreen.SetActive(false);
    }

    /// <summary>
    /// Shows model with given id
    /// </summary>
    /// <param name="id">Model's id to show</param>
    private void ShowModel(uint id)
    {
        if (id < _models.Length)
        {
            _models[_currentModel].SetActive(false);
            _currentModel = id;
            _models[id].SetActive(true);

            GetComponent<Rotation>().ResetRotation();
            CheckButtons();
        }
    }

    public void Previous()
    {
        if (_currentModel - 1 >= 0) ShowModel(_currentModel - 1);
    }

    public void Next()
    {
        if (_currentModel + 1 < _models.Length) ShowModel(_currentModel + 1);
    }

    private void CheckButtons()
    {
        if (_currentModel == 0) _previousButton.interactable = false;
        else _previousButton.interactable = true;

        if (_currentModel == _models.Length - 1) _nextButton.interactable = false;
        else _nextButton.interactable = true;
    }

}
