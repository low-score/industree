﻿using UnityEngine;
using System.Collections;
using Industree.Rendering;

namespace Industree.View
{
    public class WinLoseView : View<WinLoseViewData>
    {
        private GameController gameController;

        private void Awake()
        {
            gameController = GameController.Get();
        }

        protected override void Draw()
        {
            if (gameController.GameEnded)
            {
                if (gameController.GameWon)
                {
                    ResolutionIndependentRenderer.DrawTexture(data.dialogRectangle, data.winDialog);
                }
                else
                {
                    ResolutionIndependentRenderer.DrawTexture(data.dialogRectangle, data.loseDialog);
                }
            }
        }
    }
}
