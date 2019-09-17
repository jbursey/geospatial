using Geospatial.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Algorithms
{
    public static class Geohash
    {
        private static string ALPHABET = "0123456789bcdefghjkmnpqrstuvwxyz";

        public static string FromPoint(Point point, byte precision = 10)
        {
            return "";
        }

        public static Point FromHash(string hash)
        {
            if(String.IsNullOrEmpty(hash))
            {
                throw new Exception("Geohash cannot be null or empty");
            }

            hash = hash.ToLower();

            string binaryString = "";
            //List<string> binaryChunks = new List<string>();
            foreach(char c in hash)
            {
                //--get the decimal value for the letter
                int alphabetIndex = ALPHABET.IndexOf(c);

                //--convert this to a 5 digit binary string
                string chunk = ToBinary5(alphabetIndex);
                //binaryChunks.Add(chunk);
                binaryString += chunk;
            }

            string longitudeString = "";
            string latitudeString = "";            

            for(int i = 0; i < binaryString.Length - 1; i += 2)
            {
                char lngDigit = binaryString[i];
                char latDigit = binaryString[i + 1];

                longitudeString += lngDigit;
                latitudeString += latDigit;
            }

            double minLat = Constants.MIN_LAT;
            double minLng = Constants.MIN_LNG;
            double maxLat = Constants.MAX_LAT;
            double maxLng = Constants.MAX_LNG;

            //-- if the bit == 1 then it is greater than the midpoint
            FindMinMaxFromBinaryString(longitudeString, minLng, maxLng, out double finalLngMin, out double finalLngMax);
            FindMinMaxFromBinaryString(latitudeString, minLat, maxLat, out double finalLatMin, out double finalLatMax);

            //--geohash is just a sufficiently small box. It is not an exact point, but rather the midpoint of the final best guess area.
            double lng = (finalLngMax + finalLngMin) / 2.0;
            double lat = (finalLatMax + finalLatMin) / 2.0;

            return new Point(lng, lat);
        }        

        private static void FindMinMaxFromBinaryString(string binaryString, double min, double max, out double finalMin, out double finalMax)
        {
            foreach(var c in binaryString)
            {
                int val = int.Parse(c.ToString());
                double mid = (max + min) / 2.0;
                if (val > 0)
                {
                    min = mid;
                }
                else
                {
                    max = mid;
                }
            }

            //--outs
            finalMin = min;
            finalMax = max;
        }

        private static string ToBinary5(int index)
        {
            /*
             * binary 0 0001 ==> 1
             * binary 0 1000 ==> 8
             * binary 1 1111 ==> 1 + 2 + 4 + 8 + 16 = 31 max value or aka ALPHABET[ALPHABET.length -1] 
             * 
             * masks:
             * binary 1 1111 ==> 0x1F
             * binary 0 1111 ==> 0x0F
             * binary 0 0111 ==> 0x07
             * binary 0 0011 ==> 0x03
             * binary 0 0001 ==> 0x01
             * binary 0 0000 ==> 0x00
             * 
             * binary 1 0000 ==> 0x10
             * binary 0 1000 ==> 0x08
             * binary 0 0100 ==> 0x04
             * binary 0 0010 ==> 0x02
             * binary 0 0001 ==> 0x01
             */

            char[] binary = new char[5];
            binary[0] = '0'; //MSB
            binary[1] = '0';
            binary[2] = '0';
            binary[3] = '0';
            binary[4] = '0'; //LSB

            List<int> masks = new List<int>();
            masks.Add(0x10);
            masks.Add(0x08);
            masks.Add(0x04);
            masks.Add(0x02);
            masks.Add(0x01);

            for(int i = 0; i < masks.Count; i++)
            {
                int mask = masks[i];
                int maskedVal = index & mask;
                int val = maskedVal >> 4 - i;

                if(val == 1)
                {
                    binary[i] = '1';
                }
            }

            string binStr = new string(binary);

            return binStr;
        }

    }
}
