import './App.css';
import React, {Component} from "react";

export default class Test extends React.Component {
    constructor(props){
        super(props);
        this.state = {apiInfo: 'default'};
    }

    componentDidMount() {
        const that = this;
        fetch('https://localhost:5001/GetAllEmployee')
            .then(function(response) {
                return response.json();
            })
            .then(function(jsonData) {
                return JSON.stringify(jsonData).toString();
            })
            .then(function(jsonStr) {
                that.setState({ apiInfo: jsonStr });
            });
    }

    render() {

       for(let i = 0; i < this.state.apiInfo.length ; i++){
            return <div>{this.state.apiInfo}</div>
        }
    }
}
