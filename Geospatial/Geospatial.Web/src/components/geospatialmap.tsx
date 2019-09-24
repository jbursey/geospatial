import * as React from "react"
import * as mapboxgl from "mapbox-gl"

export interface IGeospatialMapPropActions { }
export interface IGeospatialMapPropData { }

export interface IGeospatialMapStateActions { }
export interface IGeospatialMapStateData { }

export type IGeospatialMapProps = IGeospatialMapPropActions | IGeospatialMapPropData;
export type IGeospatialMapState = IGeospatialMapStateActions | IGeospatialMapStateData;

export class GeospatialMap extends React.Component<IGeospatialMapProps, IGeospatialMapState>
{
    private _accessToken: string;

    constructor(props: IGeospatialMapProps) {
        super(props);
        //this._accessToken = "pk.eyJ1IjoiamVmZmJ1cnNleSIsImEiOiJjazB5NWJ3ZmwwY3B3M2NvYmVhMmJ4N3Q5In0.J0ur4PPFKeZbZWdv8T8BCQ";
    }

    public componentDidMount() {
        (mapboxgl as any).accessToken = "pk.eyJ1IjoiamVmZmJ1cnNleSIsImEiOiJjazB5NWJ3ZmwwY3B3M2NvYmVhMmJ4N3Q5In0.J0ur4PPFKeZbZWdv8T8BCQ";
        const map = new mapboxgl.Map({
            container: "map-workspace",
            center: { lat: 32.0, lng: -97.0 },
            style: 'mapbox://styles/mapbox/streets-v11', // stylesheet location
            zoom: 7
        });

    }

    public render(): JSX.Element {
        return (
            <div id="map-workspace">
            </div>
        )
    }
}