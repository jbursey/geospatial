import * as React from "react"
import * as ReactDom from "react-dom"
import { GeospatialMap } from "./components/geospatialmap";
import { GeospatialLayers } from "./components/geospatiallayers";

export class App extends React.Component<{}, {}>
{
    constructor(props: any) {
        super(props);
    }

    public render() {
        return (
            <div>
                <GeospatialLayers />
                <GeospatialMap />
            </div>
            )
    }
}

ReactDom.render(<App />, document.getElementById("app"));