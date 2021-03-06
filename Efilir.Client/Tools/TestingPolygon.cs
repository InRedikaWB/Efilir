﻿using System.Collections.Generic;
using System.Windows.Controls;
using Efilir.Core.Algorithms;
using Efilir.Core.Cells;
using Efilir.Core.Environment;
using Efilir.Core.Tools;

namespace Efilir.Client.Tools
{
    public class TestingPolygon
    {
        private readonly PixelDrawer _pd;
        public readonly SimulationManger CellField;

        public TestingPolygon(Image image)
        {
            _pd = new PixelDrawer(image, Configuration.FieldSize, Configuration.ScaleSize);
            int[,] field = DataSaver.LoadField();
            if (field == null)
            {
                CellField = new SimulationManger();
            }
            else
            {
                CellField = new SimulationManger(field);
            }
        }

        public void UpdateUi() => _pd.DrawPoints(CellField.GetAllCells());
        public void SimulateRound() => CellField.MakeCellsMove();
        public bool SimulationFinished => CellField.GetAliveCellCount() <= 8;
        public void SaveCells() => DataSaver.Save(CellField.GetAllGenericCells());

        public void LoadCells()
        {
            List<List<int>> jsonData = DataSaver.Load();
            List<IGenericCell> generatedCells = GeneticCellMutation.GenerateNewCells(jsonData);
            var field = DataSaver.LoadField(); 
            if(field == null)
                CellField.DeleteAllElements();
            else
                CellField.DeleteAllElements(field);

            CellField.InitializeLiveCells(generatedCells);
        }
    }
}