using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace CastleOfTheWinds
{
    public class Grid
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _cellSize;
        private Cell[,] cells;

        public Grid(int width, int height, int cellSize)
        {
            _width = width;
            _height = height;
            _cellSize = cellSize;

            InitializeGrid();
        }

        private void InitializeGrid()
        {
            cells = new Cell[_width, _height];

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    cells[x, y] = new Cell(x, y);
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            if (IsWithinBounds(x, y))
            {
                return cells[x, y];
            }
            return null;
        }

        public Cell GetCellFromWorldPosition(Vector2 worldPosition)
        {
            int x = (int)(worldPosition.X / _cellSize);
            int y = (int)(worldPosition.Y / _cellSize);
            return GetCell(x, y);
        }

        public Vector2 GetWorldPosition(int x, int y)
        {
            return new Vector2(x * _cellSize, y * _cellSize);
        }

        public List<Cell> GetNeighbors(Cell cell, bool includeDiagonals = false)
        {
            List<Cell> neighbors = new List<Cell>();

            // Orthogonal neighbors
            TryAddNeighbor(neighbors, cell.X + 1, cell.Y);
            TryAddNeighbor(neighbors, cell.X - 1, cell.Y);
            TryAddNeighbor(neighbors, cell.X, cell.Y + 1);
            TryAddNeighbor(neighbors, cell.X, cell.Y - 1);

            if (includeDiagonals)
            {
                // Diagonal neighbors
                TryAddNeighbor(neighbors, cell.X + 1, cell.Y + 1);
                TryAddNeighbor(neighbors, cell.X + 1, cell.Y - 1);
                TryAddNeighbor(neighbors, cell.X - 1, cell.Y + 1);
                TryAddNeighbor(neighbors, cell.X - 1, cell.Y - 1);
            }

            return neighbors;
        }

        private void TryAddNeighbor(List<Cell> neighbors, int x, int y)
        {
            if (IsWithinBounds(x, y))
            {
                neighbors.Add(cells[x, y]);
            }
        }

        private bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < _width && y >= 0 && y < _height;
        }

        public int Width => _width;
        public int Height => _height;
        public int CellSize => _cellSize;
    }

    public class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsWalkable { get; set; }
        public object Contents { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            IsWalkable = true;
            Contents = null;
        }
    }
}