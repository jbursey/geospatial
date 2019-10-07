using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geospatial.Tiles.Raster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geospatial.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RasterTileController : ControllerBase
    {
        private RasterTileRenderer _renderer;

        public RasterTileController(RasterTileRenderer renderer)
        {

        }

        [HttpGet]
        [Route("sample/{name}/{x}/{y}/{z}")]
        public FileContentResult GetSampleTileData(string name, int x, int y, int z)
        {
            byte[] data = null;

            FileContentResult contentResult = new FileContentResult(data, "application/octet-stream");

            return contentResult;
        }
    }
}