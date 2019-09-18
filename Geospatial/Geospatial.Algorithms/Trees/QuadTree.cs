using Geospatial.Core;
using System;
using System.Collections.Generic;

namespace Geospatial.Algorithms.Trees
{
    public class QuadTree<T> where T : ISpatialElement
    {
        private Point _sw;
        private Point _ne;

        public QuadTree(Point southWest, Point northEast, uint capacity)
        {
            Items = new List<T>();
            CellCapacity = capacity; //a cell can contain at most 5 elements, then a subdivision will occur

            _sw = southWest;
            _ne = northEast;

            _northEast = null;
            _northWest = null;
            _southEast = null;
            _southWest = null;
        }

        public uint CellCapacity { get; set; }
        public List<T> Items { get; set; }
        public bool SubdivisionOccurred
        {
            get
            {
                if (_northEast == null)
                {
                    return false;
                }

                return true;
            }
        }

        public void Insert(T item)
        {
            if(!ContainsItem(item))
            {
                return;
            }

            if(Items.Count <= CellCapacity - 1)
            {
                Items.Add(item);
            }
            else
            {
                Subdivide();

                //-- insert into whatever cell will take them
                _northEast.Insert(item);
                _northWest.Insert(item);
                _southEast.Insert(item);
                _southWest.Insert(item);

                //-- clear out the current point sturcture and insert
                foreach(var p in Items)
                {
                    _northEast.Insert(p);
                    _northWest.Insert(p);
                    _southEast.Insert(p);
                    _southWest.Insert(p);
                }
                Items.Clear();
                Items.TrimExcess();
            }
        }
        
        public List<T> Query(Polygon polygon)
        {
            //check to see if this "cell" touches this polygon

            //--if this cell could touch this polygon then query it
            List<T> results = new List<T>();
            if(SubdivisionOccurred)
            {
                results.AddRange(_northWest.Query(polygon));
                results.AddRange(_northEast.Query(polygon));
                results.AddRange(_southWest.Query(polygon));
                results.AddRange(_southEast.Query(polygon));
            }
            else
            {
                foreach(var item in Items)
                {
                    
                }
            }
            return results;
        }

        private bool ContainsItem(T p)
        {
            if(p.ContainedWithin(_sw.X, _sw.Y, _ne.X, _ne.Y))
            {
                return true;
            }
            return false;
        }

        private void Subdivide()
        {
            double midX = (_sw.X + _ne.X) / 2.0;
            double midY = (_sw.Y + _ne.Y) / 2.0;

            _northEast = new QuadTree<T>(new Point(midX, midY), new Point(_ne.X, _ne.Y), CellCapacity);
            _southWest = new QuadTree<T>(new Point(_sw.X, _sw.Y), new Point(midX, midY), CellCapacity);                                     
            _northWest = new QuadTree<T>(new Point(_sw.X, midY), new Point(midX, _ne.Y), CellCapacity);
            _southEast = new QuadTree<T>(new Point(midX, _sw.Y), new Point(_ne.X, midY), CellCapacity);
        }

        private QuadTree<T> _northEast;
        private QuadTree<T> _northWest;
        private QuadTree<T> _southEast;
        private QuadTree<T> _southWest;
    }
}
