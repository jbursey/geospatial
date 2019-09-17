using System;

namespace Geospatial.Algorithms.Trees
{
    public class QuadTree<T>
    {
        public QuadTree()
        {
            CellCapacity = 5; //a cell can contain at most 5 elements, then a subdivision will occur

            _northEast = new QuadTree<T>();
            _northWest = new QuadTree<T>();
            _southEast = new QuadTree<T>();
            _southWest = new QuadTree<T>();
        }

        public uint CellCapacity { get; set; }

        public void Insert(T item)
        {
            
        }

        private QuadTree<T> _northEast;
        private QuadTree<T> _northWest;
        private QuadTree<T> _southEast;
        private QuadTree<T> _southWest;
    }
}
