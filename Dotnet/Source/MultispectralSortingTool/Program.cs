using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static System.Console;

using ME = MetadataExtractor;
using MetadataExtractor.Formats.Xmp;

namespace MultispectralSortingTool
{
    class Program
    {
        static void Main(string[] args)
        {

            //Welcome Message
            ForegroundColor = ConsoleColor.Blue;
            WriteLine(@"  __  __      _ _   _                 _            _   ___          _   _             _____         _ 
 |  \/  |_  _| | |_(_)____ __  ___ __| |_ _ _ __ _| | / __| ___ _ _| |_(_)_ _  __ _  |_   _|__  ___| |
 | |\/| | || | |  _| (_-< '_ \/ -_) _|  _| '_/ _` | | \__ \/ _ \ '_|  _| | ' \/ _` |   | |/ _ \/ _ \ |
 |_|  |_|\_,_|_|\__|_/__/ .__/\___\__|\__|_| \__,_|_| |___/\___/_|  \__|_|_||_\__, |   |_|\___/\___/_|
                        |_|                                                   |___/                   ");

            Write($"{"v.0.1",102}\n\n");
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"Before continuing, please make sure that all images you are about to sort are placed in the same folder\nand not in subfolders.Place this program in the main folder.\n");
            ResetColor();
            WriteLine("Press any key to continue or Ctrl-C to quit...\n");
            ReadLine();

            //Variables
            int fileCounter = 0;
            string currentDir = Directory.GetCurrentDirectory();

            try
            {
                //Inform user that the directory will be modified
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Preparing directory for operation...\n");
                ResetColor();

                //Create directories per band name
                string[] bandNames = new string[] { "Red", "Green", "Blue", "RedEdge", "NIR", "RGB" };

                try
                {
                    foreach (string band in bandNames)
                    {
                        if (!Directory.Exists(band))
                        {
                            Directory.CreateDirectory(band);
                            WriteLine($"{band} directory successfully created...");
                        }
                        else
                        {
                            WriteLine($"The {band} directory already exists, skipping...");
                        }
                    }

                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("\nDirectories ready\n\n");
                    ResetColor();
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }

                //Go through each image file and move it to the corresponding band directory
                try
                {
                    //Combine the list of TIFF and TIF extension images
                    //string[] tifImages = Directory.GetFiles(currentDir, "*.TIF");
                    string[] tiffImages = (Directory.GetFiles(currentDir, ".TIFF"));
                    string[] multiSpectralImages = tiffImages.Concat(tiffImages).ToArray();

                    //Create list of RGB images
                    string[] rgbImages = Directory.GetFiles(currentDir, "*.JPG");

                    //JPG images are RGB by default
                    foreach (var image in rgbImages)
                    {
                        //Move JPG image to RGB directory
                        File.Move(image, Path.Combine(currentDir, bandNames.Last(), Path.GetFileName(image)));

                        //Increment total file count
                        fileCounter++;
                    }

                    foreach (var image in multiSpectralImages)
                    {
                        CapturedImage currentImg = new CapturedImage(image, Path.GetFileName(image));

                        IEnumerable<ME.Directory> directories = ME.ImageMetadataReader.ReadMetadata(currentImg.Path);
                        var xmpDirectory = directories.OfType<XmpDirectory>().FirstOrDefault();
                        if (xmpDirectory is not null)
                        {
                            var xmpMeta = xmpDirectory.GetXmpProperties();

                            //Assign the value stored in XMP Camera:BandName property to the current CapturedImage object
                            currentImg.Band = xmpMeta["Camera:BandName"];
                        }

                        WriteLine($"Moving {currentImg.FileName} to the {currentImg.Band} directory...");

                        //Move image to band directory
                        File.Move(currentImg.Path, Path.Combine(currentDir, currentImg.Band, currentImg.FileName));

                        //Increment total file count
                        fileCounter++;

                        //Increment band's counter
                        CapturedImage.BandsCounter[currentImg.Band]++;
                    }
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }

                ForegroundColor = ConsoleColor.Green;
                WriteLine("\nOPERATION SUCCESSFUL!\n");

                //Deliver operation stats
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("***STATS***");
                WriteLine($"\nTotal number of image(s) processed: {fileCounter}\n");

                WriteLine("Total number of images processed per band:");
                foreach (string band in bandNames)
                {
                    WriteLine($"*** {band,-8} : {CapturedImage.GetBandsCount(band)}  ***");
                }
                ResetColor();
                Write("\nDone. Press any key to close...");
                ReadKey();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

        }
    }
}
