import * as React from "react"
import { MenuItem } from "../MenuItem"

export class SideNav extends React.Component<{}, {}>
{
    constructor(props: any) {
        super(props);
    }

    public render() {
        return (
            <div id="side-nav">
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
                <MenuItem />
            </div>
            )
    }
}