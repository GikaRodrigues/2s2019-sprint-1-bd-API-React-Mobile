import React, {Component} from 'react';

export default class Profile extends Component {
    constructor() {
        super();
        this.state = {
            token: ''
        }
    }

    componentDidMount() {
        this._buscarDadosDoStorage();
    }

    _buscarDadosDoStorage = async() => {
        try {
            const tokenDoStorage = await AsyncStorage.getItem('@gufos:token');
            if (tokenDoStorage != null) {
                this.setState({ token: tokenDoStorage })
            }
        } catch (error) {}
    };

    render() {
        return (
            <View>
                <Text>{this.state.token}</Text>
            </View>
        );
    }
}