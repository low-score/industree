﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace assets.scripts.View
{
    [System.Serializable]
    public class PauseViewData : ViewData
    {
        public Rect pauseDialogRectangle;
        public Texture pauseDialog;
    }
}