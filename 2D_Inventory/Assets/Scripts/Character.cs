using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public string _name { get; private set; }
    [SerializeField] public int _level { get; private set; }
    [SerializeField] public int _gold { get; private set; }
    [SerializeField] public string _description { get; private set; }
    [SerializeField] public string _job { get; private set; }
    [SerializeField] public int _attack {  get; private set; }
    [SerializeField] public int _defense {  get; private set; }
    [SerializeField] public int _health {  get; private set; }
    [SerializeField] public int _critical {  get; private set; }
    public string Name => _name;
    public int Level => _level;
    public int Gold => _gold;
    public string Description => _description;
    public string Job => _job;

    public int Attack => _attack;
    public int Defense => _defense;
    public int Health => _health;
    public int Critical => _critical;
    public void SetData(string name, int level, int gold, string description, string job,int attack, int defense, int health, int critical)
    {
        _name = name;
        _level = level;
        _gold = gold;
        _description = description;
        _job = job;
        _attack = attack;
        _defense = defense;
        _health = health;
        _critical = critical;
    }
    void Awake()
    {
        GameManager.Instance.player = this;    
    }
}
