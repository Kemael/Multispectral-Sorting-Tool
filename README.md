![MST_Logo](https://user-images.githubusercontent.com/47387377/142050108-d22dc717-7b1a-4f89-8d11-24e18eb3360d.png)<br>
[![license](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE.md) [![language](https://img.shields.io/badge/language-.NET-blueviolet)](https://dotnet.microsoft.com) ![language](https://img.shields.io/badge/language-Python-green) ![purpose](https://img.shields.io/badge/purpose-automation-red)
<br>

# What is the Multispectral Sorting Tool?

This tool was built to solve a business process issue pertaining to the workflow of remote sensing and GIS specialists relying on the collection of substantial amounts of aerial imagery data. More specifically, imagery data containing different spectral colour bands to produce high quality orthomosaics or other georeferenced datasets. <strong>With this tool, images of different colour bands are automatically sorted in corresponding directories.</strong>

The automation of this business process has been tailored and tested on dozens of real-world cases and was most utilised when sorting data collected by the DJI Phantom Multispectral device. However, because the tool relies on the XMP metadata standard and its "camera:band" key-value pairs, this workflow has been effective with other multispectral multi-camera systems.

# Variants

The Multispectral Sorting Tool has been built in two flavours, one with Python and the other with .NET (6.0). This was done in order to offer a reasonable level of flexibility that may be required when using external Geogrophical Information System tools such as QGIS, ArcGIS, GlobalMapper, etc.

## .NET (6.0) <img src='https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-plain-wordmark.svg' alt="dotnetcore" width="40" height="40"/>

The .NET variant relies on the [MetaData Extractor Library](https://github.com/drewnoakes/metadata-extractor) which license can be found [here](https://github.com/drewnoakes/metadata-extractor/blob/master/LICENSE). It was originally developed in Java and later ported to .NET C# using sharpen. This libary is implemented as a Nuget package.

## Python 🐍

The Python variant relies on the [Python XMP Toolkit](https://python-xmp-toolkit.readthedocs.io/en/latest/). Because of this dependency however, the Python tool is not yet officially supported on the Windows platform. 

## Recommended Variant

The recommended variant to use is <strong>.NET</strong>. Indeed, it is substantially more performant as a compiled langauge and is compatible with all major platforms such as Windows and UNIX based operating systems. 

Python can still be used for specific use cases such as integration in already existing Python-based worflow/business processes.

# Usage

It is first required that all images be transferred in the same directory, preferably a new one. <strong>Images from subdirectories will be ignored.</strong> 

## .NET (6.0)

Simply download the appropriate compiled executable from the [compiled]() folder or from the following list and place said executable in the same directory where the target images are stored.

### For Windows (10 & 11)

Download from [here]()

### For MacOS (Catalina and above)

Download from [here]()

### For Ubuntu (LTS & Current)

Download from [here]()

## Python

- Import the required Python XMP Toolkit module and its dependencies using the [requirements.txt]() file with PIP.
- Execute [main.py]() in the same directory where the target images are stored.

# Performance Comparison

In order to provide insight as to what kind of performance can be expected from both variations of the Multispectral Sorting Tool, the following data was collected and processed for visualisation.

## Raw Data

## Data Visualisation


# License

[![license](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE.md) 
