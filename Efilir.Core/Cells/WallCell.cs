﻿using Efilir.Core.Algorithms;
using Efilir.Core.Types;

namespace Efilir.Core.Cells
{
    public class WallCell : IBaseCell
    {
        public Coordinate Position { get; set; }
        public void MakeTurn(IGameArea gameArea)
        {
        }
    }
}