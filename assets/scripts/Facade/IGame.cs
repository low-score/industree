﻿using System;
using UnityEngine;

namespace Industree.Facade
{
    public interface IGame
    {
        event Action GameStart;
        event Action GamePause;
        event Action GameResume;
        event Action GameEnd;
        event Action GameWin;
        event Action GameLose;

        bool HasGameStarted { get; }
        bool IsGamePaused { get; }
        bool HasGameEnded { get; }
        bool PlayerWonGame { get; }
        Texture PauseTexture { get; }
        Texture WinTexture { get; }
        Texture LoseTexture { get; }
        Rect ScreenBounds { get; }
        void StartGame();
        void PauseGame();
        void ResumeGame();
    }
}
