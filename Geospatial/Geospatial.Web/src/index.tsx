import * as React from "react"
import * as ReactDom from "react-dom"
import {SideNav, Workspace } from "./components/layout/"

export class App extends React.Component<{}, {}>
{
    constructor(props: any) {
        super(props);
    }

    public render() {
        return (
            <React.Fragment>
                <SideNav />
                <Workspace />
            </React.Fragment>
            )
    }
}

ReactDom.render(<App />, document.getElementById("app"));