import * as React from "react"

export class MenuItem extends React.Component<{}, {}>
{
    constructor(props: any) {
        super(props);
    }

    public render() {
        return (
            <div className="menu-item">
                <div className="menu-item-header">Header</div>
                <ul className="menu-item-elements">
                    <li>Element 1</li>
                    <li>Element 2</li>
                    <li>Element 3</li>
                    <li>Element 4</li>
                </ul>
            </div>
            )
    }
}