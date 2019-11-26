import React, {Component} from 'react';

import {Text, TextInput, TouchableOpacity, View, AsyncStorage} from 'react-native';

export default class SingIn extends Component {
    static navigationOptions = {
        header: null,
    };
    
    constructor() {
        super();
        this.state = {
            email: null,
            senha: null,
        };
    }
    
_realizarLogin = async () => {
    // console.warn(this.state.email + ' - ' + this.state.senha);
    fetch('http://192.168.7.85:5000/api/login', {
        method: 'POST',
        headers: {
            accept: 'application/json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            email: this.state.email,
            senha: this.state.senha,
        }),
    })
    .then(resposta => resposta.json())
    .then(data => this._irParaHome(data.token))
    .catch(erro => console.warn('deu ruimzaço' + erro));
};

_irParaHome = async tokenRecebido => {
        if (tokenRecebido != null){
            try{
            await AsyncStorage.setItem('@gufos:token', tokenRecebido);
            this.props.navigation.navigate('MainNavigator');
        } catch (error) {}
    }
};

    render() {
        return (
            <View>
                <TextInput placeholder="email" 
                    onChangeText={email => this.setState({email})} 
                    />
                <TextInput placeholder="senha" 
                    onChangeText={senha => this.setState({senha})} 
                    />
                <TouchableOpacity onPress={this._realizarLogin}>
                    <Text>Login</Text>
                </TouchableOpacity>
            </View>
        );
    }
}