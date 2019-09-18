# Simple Geospatial Library
Simple reusable geospatial functions. Geohash, point in polygon, nearest point, quad trees, etc.

## Geospatial.Core
This project contains core classes and structures needed for the other projects.

## Geospatial.Algorithms
Anything data structure wise should go here. Tree based algorithms as an example.

## Geospatial.IO
This is where IO operations for WKB, WKT, SHP, DBF, etc should be contained.

## Geospatial.Projections
Mercator projections, Transverse Mercator, etc

## Geospatial.Web
This is a demo app showcasing raster tile rendering and various usage of the other systems. There should be some WKT layers, WKB files, and SHP files that can be read into memory then partitioned into a quad tree. This quad tree is queried for each tile X/Y for bitmap rendering. 

# How to run the demo
This is a docker based app and will require you to provide your own mapbox key as an <env> variable. The following command should be ran at the .sln level. Navigate to http:://localhost:9000 to view the project.
```
docker image build -t geospatial.web -f .\Geospatial.Web\Dockerfile .
docker container run -d -p 9000:80 -e MAPBOX_ACCESS_TOKEN=<your token here> geospatial.web
```
# How to build the demo outside of Docker
Navigate to the directory for Geospatial.Web where the package.json file is located. You will need to run
```
npm install
npm run build
```

---
# TODO
1. Potentiall move projections into the Core project. Transverse mercator coordinates are needed for proper polygon area results using shoelace method.
2. Unit test for all projects with > 70% code coverage.
3. Research C# mapbox vector tile implementation / alternative to raster tiles.
4. 