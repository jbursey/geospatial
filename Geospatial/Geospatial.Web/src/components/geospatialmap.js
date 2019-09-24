"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var mapboxgl = require("mapbox-gl");
var GeospatialMap = /** @class */ (function (_super) {
    __extends(GeospatialMap, _super);
    function GeospatialMap(props) {
        return _super.call(this, props) || this;
        //this._accessToken = "pk.eyJ1IjoiamVmZmJ1cnNleSIsImEiOiJjazB5NWJ3ZmwwY3B3M2NvYmVhMmJ4N3Q5In0.J0ur4PPFKeZbZWdv8T8BCQ";
    }
    GeospatialMap.prototype.componentDidMount = function () {
        mapboxgl.accessToken = "pk.eyJ1IjoiamVmZmJ1cnNleSIsImEiOiJjazB5NWJ3ZmwwY3B3M2NvYmVhMmJ4N3Q5In0.J0ur4PPFKeZbZWdv8T8BCQ";
        var map = new mapboxgl.Map({
            container: "map-workspace",
            center: { lat: 32.0, lng: -97.0 },
            style: 'mapbox://styles/mapbox/streets-v11',
            zoom: 7
        });
    };
    GeospatialMap.prototype.render = function () {
        return (React.createElement("div", { id: "map-workspace" }));
    };
    return GeospatialMap;
}(React.Component));
exports.GeospatialMap = GeospatialMap;
//# sourceMappingURL=geospatialmap.js.map