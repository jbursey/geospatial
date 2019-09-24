import * as React from "react"
import * as mapboxgl from "mapbox-gl"

export interface IGeoSpatialLayersPropActions { }
export interface IGeoSpatialLayersPropData { }

export interface IGeoSpatialLayersStateActions { }
export interface IGeoSpatialLayersStateData { }

export type IGeoSpatialLayersProps = IGeoSpatialLayersPropActions | IGeoSpatialLayersPropData;
export type IGeoSpatialLayersState = IGeoSpatialLayersStateActions | IGeoSpatialLayersStateData;

export class GeospatialLayers extends React.Component<IGeoSpatialLayersProps, IGeoSpatialLayersState>
{
    public render(): JSX.Element {
        return (
            <div id="map-layers">
                <br />
            </div>
            )
    }
}