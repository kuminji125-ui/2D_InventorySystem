using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _level;
    [SerializeField] private int _gold;
    [SerializeField] private string _description;
    [SerializeField] private string _job;
    public void Init(string name, int level, int gold, string description, string job)
    {
        _name = name;
        _level = level;
        _gold = gold;
        _description = description;
        _job = job;
    }

    public string Name => _name;
    public int Level => _level;
    public int Gold => _gold;
    public string Description => _description;
    public string Job => _job;
}
