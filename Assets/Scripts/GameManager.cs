using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Atributos del modelo de datos
    private int _pointsPlayer1 = 0;
    private int _pointsPlayer2 = 0;

    //Referencias al gestor de HUD
    private HUDManager _HUDManager;
    public HUDManager HUDManager 
    { 
        get => _HUDManager; 
        set => _HUDManager = value; 
    }

    //Referencia a la pelota (El respawn lo gestiona el GameManager)
    private Ball _ball;
    public Ball Ball 
    { 
        get => _ball;
        set => _ball = value; 
    }
    
    //Singleton
    private static GameManager _instance = null;
    public static GameManager Instance 
    {
        get => _instance; 
    }

    private GameManager()
    {
        if (_instance == null)
        { 
            _instance = this; 
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            if (_instance != this)
            {
                Destroy(this);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
        else //Este else no debería de darse nunca porque se inicializa en el constructor
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        _HUDManager.setPoints(1, 0);
        _HUDManager.setPoints(2, 0);
    }

    public void AddPoints(int player)
    {
        if (player == 1)
        {
            _pointsPlayer1++;
            if (_HUDManager != null)
            {
                _HUDManager.setPoints(1, _pointsPlayer1);
            }
        }
        else if (player == 2)
        {
            _pointsPlayer2++;
            if (_HUDManager != null)
            {
                _HUDManager.setPoints(2, _pointsPlayer2);
            }
        }

        if (_ball != null)
        { 
            _ball.Launch();
        }
    }
}
