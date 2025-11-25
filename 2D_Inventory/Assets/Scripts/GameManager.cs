using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Character player;
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (player != null)
        {
            player.SetData("민지", 12, 123456, "모험을 막 시작한 초보자입니다.\n아직 세상에 대해 아는 것이 많지 않지만, 호기심과 열정으로 가득 차 있습니다.", "코린이", 40, 50, 100, 35);
        }
    }
}
