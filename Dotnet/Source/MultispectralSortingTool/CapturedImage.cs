using System;
using System.Collections.Generic;

namespace MultispectralSortingTool

{
    public class CapturedImage
    {
            //Auto-Implemented Properties
            public string Band { get; set; }

            public static Dictionary<string, int> BandsCounter = new Dictionary<string, int> {
            {"Red", 0},
            { "Green", 0},
            { "Blue", 0},
            { "RedEdge", 0},
            { "NIR", 0},
            { "RGB", 0}
        };
            public string Path { get; set; }
            public string FileName { get; set; }

            //Constructor
            public CapturedImage(string _Path, string _FileName)
            {
                Path = _Path;
                FileName = _FileName;
            }

            //Methods
            public static int GetBandsCount(string bandName)
            {
                return BandsCounter[bandName];
            }
        }
    }
