using Geospatial.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.IO
{
    public class ShpReader
    {
        private ByteReader _br;
        private ShpHeader _header;

        public ShpReader()
        {            

        }

        public void Parse(byte[] data)
        {
            _br = new ByteReader(data);
            
            //--parse the header
            _header = new ShpHeader();
            _header.FileCode = _br.ReadInt(false);
            _header.Unused1 = _br.ReadInt(false);
            _header.Unused2 = _br.ReadInt(false);
            _header.Unused3 = _br.ReadInt(false);
            _header.Unused4 = _br.ReadInt(false);
            _header.Unused5 = _br.ReadInt(false);
            _header.FileLength = _br.ReadInt(false);
            _header.Version = _br.ReadInt(true);
            _header.ShapeType = _br.ReadInt(true);
            _header.BoundingBoxXMin = _br.ReadDouble(true);
            _header.BoundingBoxYMin = _br.ReadDouble(true);
            _header.BoundingBoxXMax = _br.ReadDouble(true);
            _header.BoundingBoxYMax = _br.ReadDouble(true);
            _header.BoundingBoxZMin = _br.ReadDouble(true);
            _header.BoundingBoxZMax = _br.ReadDouble(true);
            _header.BoundingBoxMMin = _br.ReadDouble(true);
            _header.BoundingBoxMMax = _br.ReadDouble(true);

            //--parse the records
            switch (_header.ShapeType)
            {
                case (int)ShpType.Polygon:
                    ParsePolygons();
                    break;
                default:
                    break;
            }
            
        }

        public List<Point> OutPoints { get; set; }
        public List<Polygon> OutPolygons { get; set; }

        public struct ShpHeader
        {
            public int FileCode { get; set; } //big endian
            public int Unused1 { get; set; } //big endian
            public int Unused2 { get; set; } //big endian
            public int Unused3 { get; set; } //big endian
            public int Unused4 { get; set; } //big endian
            public int Unused5 { get; set; } //big endian
            public int FileLength { get; set; } //big endian
            public int Version { get; set; } //little endian
            public int ShapeType { get; set; } //little endian
            public double BoundingBoxXMin { get; set; } //little endian
            public double BoundingBoxYMin { get; set; } //little endian
            public double BoundingBoxXMax { get; set; } //little endian
            public double BoundingBoxYMax { get; set; } //little endian
            public double BoundingBoxZMin { get; set; } //little endian
            public double BoundingBoxZMax { get; set; } //little endian
            public double BoundingBoxMMin { get; set; } //little endian
            public double BoundingBoxMMax { get; set; } //little endian
        }

        public enum ShpType
        {
            NullShape = 0,
            Point = 1,
            PolyLine = 3,
            Polygon = 5,
            MultiPoint = 8,
            PointZ = 11,
            PolyLineZ = 13,
            PolygonZ = 15,
            MultiPointZ = 18,
            PointM = 21,
            PolyLineM = 23,
            PolygonM = 25,
            MultiPointM = 28,
            MultiPatch = 31,
        }

        public struct RecordHeader
        {
            public int RecordNumber { get; set; } //big endian
            public int ContentLength { get; set; } //big endian
        }

        public struct RecordPoint
        {
            public double X { get; set; }
            public double Y { get; set; }
        }

        public struct RecordPolygon
        {
            public double BoundingBoxMinX { get; set; }
            public double BoundingBoxMinY { get; set; }
            public double BoundingBoxMaxX { get; set; }
            public double BoundingBoxMaxY { get; set; }
            public int NumParts { get; set; }
            public int NumPoints { get; set; }
            public int[] Parts { get; set; }
            public RecordPoint[] Points { get; set; }

        }

        private void ParsePolygons()
        {
            List<Polygon> polygons = new List<Polygon>();
            while(_br.CurrentIndex < _header.FileLength * 2)
            {                

                //read some records
                RecordHeader recordHeader = new RecordHeader();
                recordHeader.RecordNumber = _br.ReadInt(false);
                recordHeader.ContentLength = _br.ReadInt(false);

                RecordPolygon recordPolygon = new RecordPolygon();
                int shpType = _br.ReadInt(true);
                recordPolygon.BoundingBoxMinX = _br.ReadDouble(true);
                recordPolygon.BoundingBoxMinY = _br.ReadDouble(true);
                recordPolygon.BoundingBoxMaxX = _br.ReadDouble(true);
                recordPolygon.BoundingBoxMaxY = _br.ReadDouble(true);
                recordPolygon.NumParts = _br.ReadInt(true);
                recordPolygon.NumPoints = _br.ReadInt(true);
                recordPolygon.Parts = new int[recordPolygon.NumParts];
                recordPolygon.Points = new RecordPoint[recordPolygon.NumPoints];                

                for(int i = 0; i < recordPolygon.NumParts; i++)
                {
                    recordPolygon.Parts[i] = _br.ReadInt(true);
                }

                List<RecordPoint> recordPoints = new List<RecordPoint>();
                for(int i = 0; i < recordPolygon.NumPoints; i++)
                {
                    RecordPoint recordPoint = new RecordPoint();
                    recordPoint.X = _br.ReadDouble(true);
                    recordPoint.Y = _br.ReadDouble(true);

                    recordPoints.Add(recordPoint);
                }

                //--split apart the parts into rings
                Polygon polygon = new Polygon();
                if(recordPolygon.NumParts > 1)
                {
                    for(int i = 0; i < recordPolygon.Parts.Length - 2; i++)
                    {
                        int startIndex = recordPolygon.Parts[i];
                        int endindex = recordPolygon.Parts[i + 1];

                        List<Point> ringPoints = new List<Point>();
                        for (int j = startIndex; j < endindex; j++)
                        {
                            RecordPoint p = recordPolygon.Points[j];
                            Point point = new Point(p.X, p.Y);
                            ringPoints.Add(point);
                        }
                        polygon.LinearRings.Add(ringPoints);
                    }
                }
                else
                {
                    List<Point> ringPoints = new List<Point>();
                    foreach(var p in recordPoints)
                    {
                        Point point = new Point(p.X, p.Y);
                        ringPoints.Add(point);
                    }
                    polygon.LinearRings.Add(ringPoints);
                }

                polygons.Add(polygon);
            }

            OutPolygons = polygons;

            int stop = 0;
        }
    }
}
