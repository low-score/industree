﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Industree.View
{
    [Serializable]
    public class ActionDeniedViewData : ViewData
    {
        public Texture deniedOverlay;
        public float overlayTime;
    }
}
